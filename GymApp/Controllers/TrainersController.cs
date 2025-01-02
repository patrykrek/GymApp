using GymApp.Commands.TrainerCommands;
using GymApp.DTO;
using GymApp.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class TrainersController : Controller
    {
        private readonly IMediator _mediator;

        public TrainersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> DisplayTrainers()
        {
            var getTrainers = await _mediator.Send(new GetTrainersQuery());

            return View(getTrainers);  
        }
        public IActionResult AddTrainers()
        {
            return View();
        }

        public async Task<IActionResult> AddTrainersForm(AddTrainersDTO trainer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTrainers",trainer);
            }

            await _mediator.Send(new AddTrainerCommand(trainer));

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> GetTrainerTrainings(int TrainerId)
        {
            var getTrainer = await _mediator.Send(new GetTrainerTrainingsQuery(TrainerId));

            return View(getTrainer);
        }
    }
}
