using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainingHandler
{
    public class GetTrainingsHandler : IRequestHandler<GetTrainingsQuery,List<GetTrainingsDTO>>
    {
        private readonly ITrainingService _trainingService;

        public GetTrainingsHandler(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task<List<GetTrainingsDTO>> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
        {
            return await _trainingService.GetAllTrainings();
        }
    }
}
