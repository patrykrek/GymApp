using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.AuthHandlers
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
