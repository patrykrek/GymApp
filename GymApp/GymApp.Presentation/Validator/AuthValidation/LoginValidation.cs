using FluentValidation;
using GymApp.GymApp.Domain.Models.ViewModels;

namespace GymApp.GymApp.Presentation.Validator.AuthValidation
{
    public class LoginValidation : AbstractValidator<LoginViewModel>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("This field can't be empty")
                .MinimumLength(6).WithMessage("Minimum length is 6");

        }
    }
}
