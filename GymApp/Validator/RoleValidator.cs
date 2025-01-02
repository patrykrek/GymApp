using FluentValidation;
using GymApp.Models;

namespace GymApp.Validator
{
    public class RoleValidator : AbstractValidator<UserRole>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("This field can't be empty");
        }
    }
}
