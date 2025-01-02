using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetTrainersQuery() : IRequest<List<GetTrainersDTO>>;
    
}
