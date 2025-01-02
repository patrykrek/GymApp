using GymApp.Commands.RoleCommands;
using GymApp.Models;
using GymApp.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
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
                return View("AssignRole",user);
            }

            await _mediator.Send(new AssignRoleCommand(user));

            return RedirectToAction("Index", "Home");

        }
    }
}
