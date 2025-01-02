using GymApp.Models;
using MediatR;

namespace GymApp.Commands.ReservCommands
{
    public record CreateReservationCommand(int TrainingId,string userId) : IRequest<Result>;
    
    
}
