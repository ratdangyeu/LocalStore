using FluentValidation;
using System;
using Unity;

namespace LocalStore.WebApp.ConfigClasses
{
    public class UnityValidatorFactory : ValidatorFactoryBase
    {
        #region Fields
        private readonly IUnityContainer _container;
        #endregion

        #region Ctor
        public UnityValidatorFactory(IUnityContainer container)
        {
            _container = container;
        }
        #endregion

        #region Methods
        public override IValidator CreateInstance(Type validatorType)
        {
            return _container.Resolve(validatorType) as IValidator;
        }
        #endregion
    }
}