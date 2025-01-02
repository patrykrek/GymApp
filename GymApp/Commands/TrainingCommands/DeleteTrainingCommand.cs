using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.TrainingCommands
{
    public record DeleteTrainingCommand(DeleteTrainingDTO training) : IRequest;
    
    
}
