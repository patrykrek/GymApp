using GymApp.Commands.AuthCommands;
using GymApp.Models;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.AuthHandlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IAuthService _authService;
        public RegisterUserHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Register(request.model);
        }
    }
}
