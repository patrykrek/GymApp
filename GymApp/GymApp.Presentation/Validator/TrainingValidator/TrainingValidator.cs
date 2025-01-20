using FluentValidation;
using GymApp.GymApp.Application.DTO;

namespace GymApp.GymApp.Presentation.Validator.TrainingValidator
{
    public class TrainingValidator : AbstractValidator<AddTrainingsDTO>
    {
        public TrainingValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("This field can't be empty");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("This field can't be empty")
                .GreaterThan(0).WithMessage("Value must be higher than 0");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("This field can't be empty")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date must be in the future");

            RuleFor(x => x.TrainerId)
                .NotEmpty().WithMessage("This field can't be empty")
                .GreaterThan(0).WithMessage("Value must be higher than 0");
        }
    }
}
