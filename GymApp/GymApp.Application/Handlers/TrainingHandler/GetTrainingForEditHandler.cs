using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.TrainingHandler
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
