using GymApp.GymApp.Application.Commands;
using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.GymApp.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new RegisterUserCommand(model));

                if (result.Success)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new LoginUserCommand(model));

                if (result.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View("VerifyEmail", model);
            }

            await _mediator.Send(new VerifyEmailCommand(model));

            return RedirectToAction("ChangePassword", "Auth", new { email = model.Email });
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ChangePassword(ChangePasswordDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePassword", request);
            }

            var result = await _mediator.Send(new ChangePasswordCommand(request));

            if (result.Success)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutUserCommand());

            return RedirectToAction("Index", "Home");
        }


    }
}
