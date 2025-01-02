using GymApp.Commands.AuthCommands;
using GymApp.Models;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.AuthHandlers
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmailCommand>
    {
        private readonly IAuthService _authService;

        public VerifyEmailHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
             await _authService.VerifyEmail(request.model);
        }
    }
}
