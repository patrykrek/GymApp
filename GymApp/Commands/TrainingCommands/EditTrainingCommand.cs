using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.TrainingCommands
{
    public record EditTrainingCommand(UpdateTrainingsDTO training) : IRequest;
    
    
}
