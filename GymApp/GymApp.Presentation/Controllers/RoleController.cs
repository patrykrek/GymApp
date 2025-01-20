using GymApp.GymApp.Application.Commands.RoleCommands;
using GymApp.GymApp.Domain.Models;
using GymApp.GymApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.GymApp.Presentation.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult AssignRole()
        {
            return View();
        }

        public async Task<IActionResult> AssignRoleForm(UserRole user)
        {
            if (!ModelState.IsValid)
            {
                return View("AssignRole", user);
            }

            await _mediator.Send(new AssignRoleCommand(user));

            return RedirectToAction("Index", "Home");

        }
    }
}
