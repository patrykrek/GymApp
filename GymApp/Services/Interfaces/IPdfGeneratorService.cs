using GymApp.DTO;

namespace GymApp.Services.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<byte[]> CreatePdfConfirmation(GetUsersReservationsDTO reservation);
    }
}
