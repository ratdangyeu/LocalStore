using AutoMapper;
using LocalStore.Domain;
using PagedList;
using System.Collections.Generic;
using System.Data.Linq;
using System;
using LocalStore.Service.Helper;
using System.Linq;

namespace LocalStore.Service
{
    public class RoleService : IRoleService
    {
        #region Fields
        private readonly LocalStoreDataContext _dataContext;
        private readonly Table<Role> _roleRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public RoleService(
            IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = new LocalStoreDataContext();
            _roleRepository = _dataContext.Roles;
        }
        #endregion

        #region Methods
        public void InsertAsync(Role entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid().ToString("D");
            do
            {
                entity.Code = HelperClass.GenCode(nameof(Role));
            } while (ExistAsync(entity.Code));

            if (entity.Code == null)
            {
                throw new ArgumentNullException(nameof(entity.Code));
            }

            _roleRepository.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();
        }

        public void UpdateAsync(Role entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var e = _roleRepository.FirstOrDefault(x => x.Id == entity.Id);
            if (e != null)
            {
                e = _mapper.Map(entity, e);
                _dataContext.SubmitChanges();
            }
        }

        public void DeleteAsync(IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = _roleRepository.Where(x => ids.Contains(x.Id));

            _roleRepository.DeleteAllOnSubmit(entities.ToArray());
            _dataContext.SubmitChanges();
        }

        public bool ExistAsync(string code)
        {
            return _roleRepository.Any(
                x => x.Code != null &&
                x.Code.Equals(code));
        }

        public void ActivationAsync(IEnumerable<string> ids, bool status)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = _roleRepository.Where(x => ids.Contains(x.Id));

            foreach(var e in entities)
            {
                e.Inactive = status;
            }
            _dataContext.SubmitChanges();
        }

        public Role GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var e = _roleRepository.FirstOrDefault(x => x.Id == id);

            return e;
        }
        #endregion

        #region List
        public IEnumerable<Role> GetAll(bool showHidden = false)
        {
            var query = from p in _roleRepository select p;

            if (!showHidden)
            {
                query = from p in query
                        where !p.Inactive
                        select p;
            }

            query = from p in query orderby p.Code select p;

            return query.ToArray();
        }

        public IPagedList<Role> Get(RoleSearchContext ctx)
        {
            ctx.Code = ctx.Code?.Trim();
            ctx.Name = ctx.Name?.Trim();

            var query = from p in _roleRepository select p;

            if (ctx.Code != null && ctx.Code.Length > 0)
            {
                query = from p in query
                        where p.Code.Contains(ctx.Code)
                        select p;
            }

            if (ctx.Name != null && ctx.Name.Length > 0)
            {
                query = from p in query
                        where p.Name.Contains(ctx.Name)
                        select p;
            }

            query = from p in query orderby p.Code select p;

            return new PagedList<Role>(query, ctx.PageNumber, ctx.PageSize);
        }
        #endregion
    }
}
