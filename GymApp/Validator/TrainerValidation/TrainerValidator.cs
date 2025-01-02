using FluentValidation;
using GymApp.DTO;

namespace GymApp.Validator.TrainerValidation
{
    public class TrainerValidator : AbstractValidator<AddTrainersDTO>
    {
        public TrainerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Bio)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.PhotoPath)
                .NotEmpty().WithMessage("This field can't be empty");
        }
    }
}
