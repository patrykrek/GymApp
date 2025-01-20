
using GymApp.GymApp.Application.Commands.PdfGeneratorCommands;
using GymApp.GymApp.Application.Commands.ReservCommands;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymApp.GymApp.Presentation.Controllers
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

        public async Task<IActionResult> DownloadPdf(DateTime ReservationDate, string Name, string Description, DateTime StartDate)
        {
            var reservation = new GetUsersReservationsDTO
            {
                ReservationDate = ReservationDate,
                Training = new Training
                {
                    Name = Name,
                    Description = Description,
                    StartDate = StartDate
                }
            };

            var pdfBytes = await _mediator.Send(new GeneratePdfCommand(reservation));

            return File(pdfBytes, "application/pdf", "TrainingConfirmation.pdf");
        }
    }
}
