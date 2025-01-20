using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainerHandlers
{
    public class GetTrainersHandler : IRequestHandler<GetTrainersQuery, List<GetTrainersDTO>>
    {
        private readonly ITrainerService _trainerService;

        public GetTrainersHandler(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task<List<GetTrainersDTO>> Handle(GetTrainersQuery request, CancellationToken cancellationToken)
        {
            return await _trainerService.GetTrainers();
        }
    }
}
