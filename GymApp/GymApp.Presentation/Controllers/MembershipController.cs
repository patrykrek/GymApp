using GymApp.GymApp.Application.Commands.MembershipCommands;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymApp.GymApp.Presentation.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMediator _mediator;


        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult AddMembership()
        {
            return View();
        }

        public async Task<IActionResult> AddMembershipForm(AddMembershipDTO membership)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMembership", membership);
            }

            await _mediator.Send(new AddMembershipCommand(membership));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DisplayMemberships()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var userMembershipExists = await _mediator.Send(new CheckUserMembershipQuery(userId)); // checks if user has membership if has displaying his membership if not displaying memberships which he can choose

            if (userMembershipExists.Success == true)
            {
                return RedirectToAction("DisplayUserMembership");
            }

            var getMemberships = await _mediator.Send(new GetMembershipsQuery());

            return View(getMemberships);
        }

        public async Task<IActionResult> DisplayUserMembership()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var UserMemberships = await _mediator.Send(new GetUserMembershipQuery(userId));


            return View(UserMemberships);


        }

        public async Task<IActionResult> BuyMembership(int membershipId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new BuyMembershipCommand(membershipId, userId));

            return RedirectToAction("Index", "Home");
        }



    }
}
