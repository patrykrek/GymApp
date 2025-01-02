using GymApp.Commands.TrainingCommands;
using GymApp.DTO;
using GymApp.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly IMediator _mediator;

        public TrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> DisplayTrainings()
        {
            var trainings = await _mediator.Send(new GetTrainingsQuery());

            return View(trainings);
        }

        public IActionResult AddTrainings()
        {
            return View();  
        }

        public async Task<IActionResult> AddTrainingsForm(AddTrainingsDTO training)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTrainings", training);
            }

            await _mediator.Send(new AddTrainingCommand(training));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteTraining(DeleteTrainingDTO training)
        {
            await _mediator.Send(new DeleteTrainingCommand(training));

            return RedirectToAction("DisplayTrainings");
        }

        public async Task<IActionResult> EditTrainings(int TrainingId)
        {
            var GetTrainingForEdit = await _mediator.Send(new GetTrainingForEditQuery(TrainingId));

            return View(GetTrainingForEdit);
        }

        public async Task<IActionResult> EditTrainingsForm(UpdateTrainingsDTO training)
        {
            await _mediator.Send(new EditTrainingCommand(training));

            return RedirectToAction("DisplayTrainings");

            
        }
    }
}
