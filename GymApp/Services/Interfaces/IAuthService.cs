using GymApp.DTO;
using GymApp.Models;
using GymApp.Models.ViewModels;

namespace GymApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result> Login(LoginViewModel login);
        Task<Result> Register(RegisterViewModel register);
        Task VerifyEmail(VerifyEmailDTO model);
        Task<Result> ChangePassword(ChangePasswordDTO request);
        Task Logout();
    }
}
