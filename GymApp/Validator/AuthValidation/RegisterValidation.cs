using FluentValidation;
using GymApp.Models.ViewModels;

namespace GymApp.Validator.AuthValidation
{
    public class RegisterValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("This field can't be empty")
                .MinimumLength(6).WithMessage("Mininmum length is 6");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("This field can't be empty")
                .Equal(x => x.Password).WithMessage("Incorrect password");
        }
    }
}
