using AutoMapper;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Models;

namespace LocalStore.WebApp.MapperProfile
{
    public class LocalStoreProfile : Profile
    {
        public LocalStoreProfile()
        {
            #region WareHouse
            CreateMap<Warehouse, WareHouseModel>();
            CreateMap<WareHouseModel, Warehouse>()
                .ForMember(x => x.Code, opt => opt.Ignore());
            CreateMap<Warehouse, Warehouse>()
                .ForMember(x => x.Code, opt => opt.Ignore());

            CreateMap<WareHouseSearchModel, WareHouseSearchContext>();
            #endregion
        }
    }
}