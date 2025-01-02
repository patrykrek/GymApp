using FluentValidation;
using GymApp.DTO;

namespace GymApp.Validator.AuthValidation
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
