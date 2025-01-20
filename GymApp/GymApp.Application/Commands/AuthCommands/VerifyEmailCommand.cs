using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Commands.AuthCommands
{
    public record VerifyEmailCommand(VerifyEmailDTO model) : IRequest;


}
