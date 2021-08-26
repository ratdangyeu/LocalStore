using AutoMapper;
using LocalStore.WebApp.MapperConfig.MapperProfile;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LocalStore.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // Automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LocalStoreProfile());
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            // Services
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}