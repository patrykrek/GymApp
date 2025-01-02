using GymApp.Commands.AuthCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.AuthHandlers
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
