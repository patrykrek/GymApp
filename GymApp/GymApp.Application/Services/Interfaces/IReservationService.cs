using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IReservationService
    {
        Task<Result> CreateReservation(int TrainingId, string userId);
        Task<List<GetUsersReservationsDTO>> GetUserReservations(string userId);
        Task<List<GetReservationsDTO>> GetReservations();
    }
}
