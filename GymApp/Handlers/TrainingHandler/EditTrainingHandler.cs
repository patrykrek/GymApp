using GymApp.Commands.TrainingCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainingHandler
{
    public class EditTrainingHandler : IRequestHandler<EditTrainingCommand>
    {
        private readonly ITrainingService _trainingService;

        public EditTrainingHandler(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task Handle(EditTrainingCommand request, CancellationToken cancellationToken)
        {
            await _trainingService.EditTraining(request.training);
        }
    }
}
