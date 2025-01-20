using GymApp.GymApp.Application.DTO;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<byte[]> CreatePdfConfirmation(GetUsersReservationsDTO reservation);
    }
}
