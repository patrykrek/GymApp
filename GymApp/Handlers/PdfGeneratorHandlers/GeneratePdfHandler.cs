using GymApp.Commands.PdfGeneratorCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.PdfGeneratorHandlers
{
    public class GeneratePdfHandler : IRequestHandler<GeneratePdfCommand, byte[]>
    {
        private readonly IPdfGeneratorService _pdfGeneratorService;

        public GeneratePdfHandler(IPdfGeneratorService pdfGeneratorService)
        {
            _pdfGeneratorService = pdfGeneratorService;
        }

        public async Task<byte[]> Handle(GeneratePdfCommand request, CancellationToken cancellationToken)
        {
            return await _pdfGeneratorService.CreatePdfConfirmation(request.reservation);
                
        }
    }
}
