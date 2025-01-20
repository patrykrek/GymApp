using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Commands.TrainerCommands
{
    public record AddTrainerCommand(AddTrainersDTO trainer) : IRequest;


}
