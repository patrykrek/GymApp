using GymApp.DTO;
using GymApp.Models;

namespace GymApp.Services.Interfaces
{
    public interface IReservationService
    {
        Task<Result> CreateReservation(int TrainingId, string userId);
        Task<List<GetUsersReservationsDTO>> GetUserReservations(string userId);
        Task<List<GetReservationsDTO>> GetReservations();
    }
}
