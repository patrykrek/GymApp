using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.TrainingCommands
{
    public record AddTrainingCommand(AddTrainingsDTO training) : IRequest;
    
}
