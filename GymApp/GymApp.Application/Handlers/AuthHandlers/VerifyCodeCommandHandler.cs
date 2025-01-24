using GymApp.GymApp.Application.Commands.AuthCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.AuthHandlers
{
    public class VerifyCodeCommandHandler : IRequestHandler<VerifyCodeCommand, bool>
    {
        private readonly IOneTimeCodeService _oneTimeCodeService;

        public VerifyCodeCommandHandler(IOneTimeCodeService oneTimeCodeService)
        {
            _oneTimeCodeService = oneTimeCodeService;
        }

        public async Task<bool> Handle(VerifyCodeCommand request, CancellationToken cancellationToken)
        {
            return await _oneTimeCodeService.ValidateCode(request.UserId, request.code);
        }
    }

}
