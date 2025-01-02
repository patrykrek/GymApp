using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetTrainerTrainingsQuery(int TrainerId) : IRequest<GetTrainersDTO>;
    
}
