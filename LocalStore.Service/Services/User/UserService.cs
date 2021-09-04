using AutoMapper;
using LocalStore.Domain;
using LocalStore.Service.Helper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LocalStore.Service
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly LocalStoreDataContext _dataContext;
        private readonly Table<User> _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UserService(IMapper mapper)
        {
            _dataContext = new LocalStoreDataContext();
            _userRepository = _dataContext.Users;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public void InsertAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid().ToString("D");
            do
            {
                entity.Code = HelperClass.GenCode(nameof(User));
            } while (ExistAsync(entity.Code));

            if (entity.Code == null)
            {
                throw new ArgumentNullException(nameof(entity.Code));
            }

            entity.Password = HelperClass.HashPassword(entity.Password);
            entity.CreatedDate = entity.ModifiedDate = DateTime.UtcNow;

            _userRepository.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();
        }

        public void UpdateAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var e = _userRepository.FirstOrDefault(x => x.Id == entity.Id);

            if (e != null)
            {
                if (!entity.Password.Equals(e.Password))
                {
                    entity.Password = HelperClass.HashPassword(entity.Password);
                }                
                e = _mapper.Map(entity, e);
                e.ModifiedDate = DateTime.UtcNow;
                _dataContext.SubmitChanges();
            }
        }

        public void DeleteAsync(IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = from p in _userRepository where ids.Contains(p.Id) select p;

            _userRepository.DeleteAllOnSubmit(entities.ToArray());
            _dataContext.SubmitChanges();
        }

        public bool ExistAsync(string code)
        {
            return _userRepository.Any(
                x => x.Code != null
                && x.Code.Equals(code));
        }

        public bool ExistAsyncEmail(string email)
        {
            return _userRepository.Any(
                x => x.Email != null
                && x.Email.Equals(email));
        }

        public bool LoginAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return _userRepository.Any(
                x => x.Email != null
                && x.Email.Equals(entity.Email)
                && x.Password != null
                && x.Password.Equals(HelperClass.HashPassword(entity.Password)));
        }

        public void ActivationAsync(IEnumerable<string> ids, bool status)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = from p in _userRepository where ids.Contains(p.Id) select p;

            foreach(var e in entities)
            {
                e.Inactive = status;
            }
            _dataContext.SubmitChanges();
        }

        public User GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = _userRepository.FirstOrDefault(x => x.Id == id);

            if (entity != null && entity.UserRoles != null)
            {
                entity.UserRoles = null;
            }

            return entity;
        }
        #endregion

        #region List
        public IEnumerable<User> GetAll(bool showHidden = false)
        {
            var query = from p in _userRepository select p;

            if (!showHidden)
            {
                query = from p in query where !p.Inactive select p;
            }

            query = from p in query orderby p.Code select p;

            foreach(var e in query)
            {
                e.UserRoles = null;
            }

            return query.ToArray();
        }

        public IPagedList<User> Get(UserSearchContext ctx)
        {
            ctx.Email = ctx.Email?.Trim();
            ctx.Code = ctx.Code?.Trim();

            var query = from p in _userRepository select p;

            if (ctx.Email != null && ctx.Email.Length > 0)
            {
                query = from p in _userRepository
                        where p.Email.Contains(ctx.Email)
                        select p;
            }

            if (ctx.Code != null && ctx.Code.Length > 0)
            {
                query = from p in _userRepository
                        where p.Code.Contains(ctx.Code)
                        select p;
            }

            query = from p in query orderby p.Code select p;

            foreach(var e in query)
            {
                e.UserRoles = null;
            }

            return new PagedList<User>(query, ctx.PageNumber, ctx.PageSize);
        }
        #endregion
    }
}
