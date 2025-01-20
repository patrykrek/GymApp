using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models;
using GymApp.GymApp.Domain.Models.ViewModels;

namespace GymApp.GymApp.Application.Services.Interfaces
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
