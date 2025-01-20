using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Queries
{
    public record GetTrainerTrainingsQuery(int TrainerId) : IRequest<GetTrainersDTO>;

}
