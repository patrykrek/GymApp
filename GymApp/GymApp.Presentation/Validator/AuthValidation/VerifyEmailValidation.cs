using FluentValidation;
using GymApp.GymApp.Application.DTO;

namespace GymApp.GymApp.Presentation.Validator.AuthValidation
{
    public class VerifyEmailValidation : AbstractValidator<VerifyEmailDTO>
    {
        public VerifyEmailValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field can't be empty");
        }
    }
}
