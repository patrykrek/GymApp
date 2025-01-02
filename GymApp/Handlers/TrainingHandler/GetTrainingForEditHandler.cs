using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.TrainingHandler
{
    public class GetTrainingForEditHandler : IRequestHandler<GetTrainingForEditQuery, UpdateTrainingsDTO>
    {
        private readonly ITrainingService _trainingService;

        public GetTrainingForEditHandler(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task<UpdateTrainingsDTO> Handle(GetTrainingForEditQuery request, CancellationToken cancellationToken)
        {
            return await _trainingService.GetTrainingForEdit(request.TrainingId);
        }
    }
}
