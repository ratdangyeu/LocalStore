using FluentValidation;
using LocalStore.WebApp.Resources;
using System;

namespace LocalStore.WebApp.Models
{
    public class StoreModel : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool Inactive { get; set; }

        public string UserId { get; set; }

        public string BusinessModel { get; set; }

        public string ParentId { get; set; }

        public string Path { get; set; }

        public StoreModel()
        {
            Inactive = false;
        }
    }

    public class StoreValidator : AbstractValidator<StoreModel>
    {
        public StoreValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(CommonString.StoreNameRequired);
            RuleFor(x => x.Name).MaximumLength(255)
                .WithMessage(string.Format(CommonString.StoreNameLength, 255));
        }
    }
}