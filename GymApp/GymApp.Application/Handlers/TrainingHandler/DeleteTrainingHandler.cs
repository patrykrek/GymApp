using GymApp.GymApp.Application.Commands.TrainingCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainingHandler
{
    public class DeleteTrainingHandler : IRequestHandler<DeleteTrainingCommand>
    {
        private readonly ITrainingService _trainingService;

        public DeleteTrainingHandler(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            await _trainingService.DeleteTraining(request.training);
        }
    }
}
