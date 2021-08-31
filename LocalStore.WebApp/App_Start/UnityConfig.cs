using AutoMapper;
using FluentValidation;
using LocalStore.Service;
using LocalStore.WebApp.Helper;
using LocalStore.WebApp.MapperConfig.MapperProfile;
using LocalStore.WebApp.Models;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
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

            // Validator
            container.RegisterType<IValidatorFactory, UnityValidatorFactory>(
                new ContainerControlledLifetimeManager());

            container.RegisterType<IValidator<WareHouseModel>, WareHouseValidator>(
                new ContainerControlledLifetimeManager());

            // Automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LocalStoreProfile());
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            // Services
            container.RegisterType<IWareHouseService, WareHouseService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}