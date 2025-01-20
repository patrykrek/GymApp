using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.AuthHandlers
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
