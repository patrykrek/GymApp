using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.AuthHandlers
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
