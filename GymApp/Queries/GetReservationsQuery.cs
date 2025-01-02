using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetReservationsQuery : IRequest<List<GetReservationsDTO>>;
    
    
}
