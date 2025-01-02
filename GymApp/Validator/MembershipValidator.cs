using FluentValidation;
using GymApp.DTO;

namespace GymApp.Validator
{
    public class MembershipValidator : AbstractValidator<AddMembershipDTO>
    {

        public MembershipValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.PricePerMonth)
                .NotEmpty().WithMessage("This field can't be empty")
                .GreaterThan(0).WithMessage("Value must be higher than 0");

        }
    }
}
