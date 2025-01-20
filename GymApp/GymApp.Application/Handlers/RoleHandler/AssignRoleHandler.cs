using GymApp.GymApp.Application.Commands.RoleCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.RoleHandler
{
    public class AssignRoleHandler : IRequestHandler<AssignRoleCommand>
    {
        private readonly IRoleService _roleService;

        public AssignRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.AssignRole(request.user);
        }
    }
}
