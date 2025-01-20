using GymApp.GymApp.Application.Commands.TrainerCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainerHandlers
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
