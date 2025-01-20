using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Queries
{
    public record GetTrainersQuery() : IRequest<List<GetTrainersDTO>>;

}
