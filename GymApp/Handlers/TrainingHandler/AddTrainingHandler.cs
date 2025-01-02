using GymApp.Commands.TrainingCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainingHandler
{
    public class AddTrainingHandler : IRequestHandler<AddTrainingCommand>
    {
        private readonly ITrainingService _trainingService;

        public AddTrainingHandler(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task Handle(AddTrainingCommand request, CancellationToken cancellationToken)
        {
            await _trainingService.AddTraining(request.training);
        }
    }
}
