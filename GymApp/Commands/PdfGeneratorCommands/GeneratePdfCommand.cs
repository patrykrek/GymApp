using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.PdfGeneratorCommands
{
    public record GeneratePdfCommand(GetUsersReservationsDTO reservation) : IRequest<byte[]>;
    
    
}
