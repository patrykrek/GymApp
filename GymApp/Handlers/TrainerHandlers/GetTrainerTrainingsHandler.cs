using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainerHandlers
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
