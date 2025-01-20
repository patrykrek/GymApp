using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.AuthHandlers
{
    public class LogoutUserHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly IAuthService _authService;
        public LogoutUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _authService.Logout();
        }
    }
}
