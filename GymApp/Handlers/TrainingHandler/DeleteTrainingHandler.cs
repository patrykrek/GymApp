using GymApp.Commands.TrainingCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainingHandler
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
