using FluentValidation;
using LocalStore.WebApp.Resources;

namespace LocalStore.WebApp.Models
{
    public class WareHouseModel : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string ParentId { get; set; }

        public string Path { get; set; }

        public bool Inactive { get; set; }

        public WareHouseModel()
        {
            Inactive = false;
        }
    }

    public class WareHouseValidator : AbstractValidator<WareHouseModel>
    {
        public WareHouseValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(CommonString.WareHouseNameRequired);
            RuleFor(x => x.Name).MaximumLength(100)
                .WithMessage(string.Format(CommonString.WareHouseNameLength, 100));

            RuleFor(x => x.Address).MaximumLength(255)
                .WithMessage(string.Format(CommonString.CommonAddressLength, 255));

            RuleFor(x => x.Description).MaximumLength(255)
                .WithMessage(string.Format(CommonString.CommonDescriptionLength, 255));
        }
    }
}