using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetUserReservationsQuery(string userId) : IRequest<List<GetUsersReservationsDTO>>;
    
    
}
