using GymApp.Commands.TrainerCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainerHandlers
{
    public class AddTrainerHandler : IRequestHandler<AddTrainerCommand>
    {
        private readonly ITrainerService _trainerService;
        public AddTrainerHandler(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task Handle(AddTrainerCommand request, CancellationToken cancellationToken)
        {
            await _trainerService.AddTrainer(request.trainer);
        }
    }
}
