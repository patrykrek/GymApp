using GymApp.Commands.AuthCommands;
using GymApp.Models;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.AuthHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result>
    {
        private readonly IAuthService _authService;
        public LoginUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Login(request.model);
        }
    }
}
