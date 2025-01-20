using GymApp.GymApp.Application.Commands.TrainingCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainingHandler
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
