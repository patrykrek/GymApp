using GymApp.Commands.ReservCommands;
using GymApp.Queries;
using GymApp.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;
       

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        public async Task<IActionResult> CreateReservation(int TrainingId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _mediator.Send(new CreateReservationCommand(TrainingId, userId));

            if (!result.Success)
            {
                return RedirectToAction("DisplayMemberships", "Membership");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DisplayUserReservations() // user displaying only his own reservations
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var getReserv = await _mediator.Send(new GetUserReservationsQuery(userId));

            return View(getReserv);

        }

        public async Task<IActionResult> DisplayReservations() // admin displaying every reservation
        {
            var getReserv = await _mediator.Send(new GetReservationsQuery());

            return View(getReserv);
        } 
    }
}
