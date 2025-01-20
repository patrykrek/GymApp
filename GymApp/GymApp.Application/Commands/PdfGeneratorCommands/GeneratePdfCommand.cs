using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Commands.PdfGeneratorCommands
{
    public record GeneratePdfCommand(GetUsersReservationsDTO reservation) : IRequest<byte[]>;


}
