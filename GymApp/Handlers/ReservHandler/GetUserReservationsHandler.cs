using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.ReservHandler
{
    public class GetUserReservationsHandler : IRequestHandler<GetUserReservationsQuery, List<GetUsersReservationsDTO>>
    {
        private readonly IReservationService _reservationService;

        public GetUserReservationsHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<List<GetUsersReservationsDTO>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
        {
            return await _reservationService.GetUserReservations(request.userId);
        }
    }
}
