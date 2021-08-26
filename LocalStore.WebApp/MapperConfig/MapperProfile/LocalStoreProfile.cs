using AutoMapper;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Models;

namespace LocalStore.WebApp.MapperConfig.MapperProfile
{
    public class LocalStoreProfile : Profile
    {
        public LocalStoreProfile()
        {
            #region WareHouse
            CreateMap<Warehouse, WareHouseModel>();
            CreateMap<WareHouseModel, Warehouse>();
            CreateMap<Warehouse, Warehouse>();

            CreateMap<WareHouseSearchModel, WareHouseSearchContext>();
            #endregion
        }
    }
}