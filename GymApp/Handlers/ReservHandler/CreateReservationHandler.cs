using GymApp.Commands.ReservCommands;
using GymApp.Models;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.ReservHandler
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand,Result>
    {
        private readonly IReservationService _reservationService;

        public CreateReservationHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            return await _reservationService.CreateReservation(request.TrainingId, request.userId);
        }
    }
}
