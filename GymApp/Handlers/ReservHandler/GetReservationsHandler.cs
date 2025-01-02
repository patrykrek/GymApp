using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.ReservHandler
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsQuery, List<GetReservationsDTO>>
    {
        private readonly IReservationService _reservationService;

        public GetReservationsHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;   
        }

        public async Task<List<GetReservationsDTO>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            return await _reservationService.GetReservations();
        }
    }
}
