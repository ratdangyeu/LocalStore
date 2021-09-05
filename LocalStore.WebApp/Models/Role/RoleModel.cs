using FluentValidation;
using LocalStore.WebApp.Resources;

namespace LocalStore.WebApp.Models
{
    public class RoleModel : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public bool Inactive { get; set; } 

        public RoleModel()
        {
            Inactive = false;
        }
    }

    public class RoleValidator : AbstractValidator<RoleModel>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(CommonString.RoleNameRequired);
            RuleFor(x => x.Name).MaximumLength(50)
                .WithMessage(string.Format(CommonString.RoleNameLength, 50));
        }
    }
}