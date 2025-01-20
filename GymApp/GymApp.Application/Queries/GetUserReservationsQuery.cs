using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Queries
{
    public record GetUserReservationsQuery(string userId) : IRequest<List<GetUsersReservationsDTO>>;


}
