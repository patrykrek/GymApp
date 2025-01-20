using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Commands.TrainingCommands
{
    public record AddTrainingCommand(AddTrainingsDTO training) : IRequest;

}
