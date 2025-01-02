using FluentValidation;
using GymApp.DTO;

namespace GymApp.Validator.AuthValidation
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("This field can't be empty")
                .MinimumLength(6).WithMessage("Minimum length is 6");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage("This field can't be empty")
                .Equal(x => x.NewPassword).WithMessage("Incorrect password");
        }
    }
}
