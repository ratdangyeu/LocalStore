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
            #region Role
            CreateMap<RoleModel, Role>()
                .ForMember(x => x.Code, opt => opt.Ignore());
            CreateMap<Role, RoleModel>();
            CreateMap<Role, Role>()
                .ForMember(x => x.Code, opt => opt.Ignore());

            CreateMap<RoleSearchModel, RoleSearchContext>();
            #endregion

            #region User
            CreateMap<User, UserModel>()
                .ForMember(x => x.RetypePassword, opt => opt.Ignore());
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