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
            #region User
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>()
                .ForMember(x => x.Code, opt => opt.Ignore())
                .ForMember(x => x.UserRoles, opt => opt.Ignore());
            CreateMap<User, User>()
                .ForMember(x => x.Code, opt => opt.Ignore())
                .ForMember(x => x.UserRoles, opt => opt.Ignore());

            CreateMap<UserSearchModel, UserSearchContext>();
            #endregion

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