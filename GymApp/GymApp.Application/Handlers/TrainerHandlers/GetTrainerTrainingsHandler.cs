using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainerHandlers
{
    public class GetTrainerTrainingsHandler : IRequestHandler<GetTrainerTrainingsQuery, GetTrainersDTO>
    {
        private readonly ITrainerService _trainerService;

        public GetTrainerTrainingsHandler(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task<GetTrainersDTO> Handle(GetTrainerTrainingsQuery request, CancellationToken cancellationToken)
        {
            return await _trainerService.GetTrainerTrainings(request.TrainerId);
        }
    }
}
