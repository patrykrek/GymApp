using GymApp.GymApp.Application.Commands.ReservCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.ReservHandler
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, Result>
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
