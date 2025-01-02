using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.TrainerCommands
{
    public record AddTrainerCommand(AddTrainersDTO trainer) : IRequest;
    
    
}
