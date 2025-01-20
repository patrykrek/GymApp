using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Queries
{
    public record GetTrainingForEditQuery(int TrainingId) : IRequest<UpdateTrainingsDTO>;


}
