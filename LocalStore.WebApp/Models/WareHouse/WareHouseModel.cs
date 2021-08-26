using FluentValidation;

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
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage("Mã không được để trống");
            RuleFor(x => x.Code).MaximumLength(255)
                .WithMessage("Mã không quá 255 ký tự");

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Tên không được để trống");
            RuleFor(x => x.Name).MaximumLength(255)
                .WithMessage("Tên không quá 255 ký tự");

            RuleFor(x => x.Address).MaximumLength(255)
                .WithMessage("Địa chỉ không quá 255 ký tự");

            RuleFor(x => x.Description).MaximumLength(255)
                .WithMessage("Mô tả không quá 255 ký tự");
        }
    }
}