using FluentValidation;
using LocalStore.WebApp.Resources;

namespace LocalStore.WebApp.Models
{
    public class UserModel : BaseModel
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Inactive { get; set; }
    }

    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage(CommonString.UserFirstNameRequired);
            RuleFor(x => x.FirstName).MaximumLength(50)
                .WithMessage(string.Format(CommonString.UserFirstNameLength, 50));

            RuleFor(x => x.LastName).MaximumLength(50)
                .WithMessage(string.Format(CommonString.UserLastNameLength, 50));

            RuleFor(x => x.Email).NotEmpty()
                .WithMessage(CommonString.UserEmailRequired);
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(CommonString.UserEmailFormat);

            RuleFor(x => x.Password).MaximumLength(255)
                .WithMessage(string.Format(CommonString.UserPasswordLength, 255));
        }
    }
}