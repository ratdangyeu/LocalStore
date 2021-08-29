using AutoMapper;
using LocalStore.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LocalStore.Service
{
    public class WareHouseService : IWareHouseService
    {
        #region Fields
        private readonly LocalStoreDataContext _dataContext;
        private readonly Table<Warehouse> _warehouseRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public WareHouseService(IMapper mapper)
        {
            _dataContext = new LocalStoreDataContext();
            _warehouseRepository = _dataContext.Warehouses;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public void InsertAsync(Warehouse entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid().ToString("D");

            _warehouseRepository.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();            
        }

        public void UpdateAsync(Warehouse entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var e = _warehouseRepository.FirstOrDefault(x => x.Id == entity.Id);

            if (e != null)
            {
                e = _mapper.Map<Warehouse>(entity);
                _dataContext.SubmitChanges();
            }
        }

        public void DeleteAsync(IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = _warehouseRepository.Where(x => ids.Contains(x.Id));

            _warehouseRepository.DeleteAllOnSubmit(entities.ToArray());
            _dataContext.SubmitChanges();
        }

        public bool ExistAsync(string code)
        {
            return _warehouseRepository.Any(
                x => x.Code != null &&
                x.Code.Equals(code));
        }

        public void ActivationAsync(IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var query = from p in _warehouseRepository
                        where ids.Contains(p.Id)
                        select p;
            foreach(var e in query)
            {
                e.Inactive = !e.Inactive;
            }
            _dataContext.SubmitChanges();
        }

        public Warehouse GetByIdAsync(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var result = _warehouseRepository.FirstOrDefault(x => x.Id == id);

            return result;
        }
        #endregion

        #region List
        public IEnumerable<Warehouse> GetAll(bool showHidden = false)
        {
            var query = from p in _warehouseRepository
                        where !p.Inactive
                        select p;
            if (showHidden)
            {
                query = from p in _warehouseRepository
                        where p.Inactive
                        select p;                
            }
            return query.ToArray();
        }

        public IPagedList<Warehouse> Get(WareHouseSearchContext ctx)
        {
            ctx.Code = ctx.Code?.Trim();
            ctx.Name = ctx.Name?.Trim();         

            var query = from p in _warehouseRepository select p;

            if (ctx.Code != null && ctx.Code.Length > 0)
            {
                query = from p in query
                        where p.Code != null && p.Code.Contains(ctx.Code)                              
                        select p;
            }

            if (ctx.Name != null && ctx.Name.Length > 0)
            {
                query = from p in query
                        where p.Name != null && p.Name.Contains(ctx.Name)
                        select p;
            }

            query = from p in query orderby p.Code select p;

            return new PagedList<Warehouse>(query, ctx.PageNumber, ctx.PageSize);
        }
        #endregion
    }
}
