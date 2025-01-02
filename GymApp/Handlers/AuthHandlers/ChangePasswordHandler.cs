using GymApp.Commands.AuthCommands;
using GymApp.Models;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.AuthHandlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IAuthService _authService;

        public ChangePasswordHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _authService.ChangePassword(request.request);
        }
    }
}
