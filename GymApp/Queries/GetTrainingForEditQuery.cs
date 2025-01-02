using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetTrainingForEditQuery(int TrainingId) : IRequest<UpdateTrainingsDTO>;
    
    
}
