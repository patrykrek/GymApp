using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Commands.ReservCommands
{
    public record CreateReservationCommand(int TrainingId, string userId) : IRequest<Result>;


}
