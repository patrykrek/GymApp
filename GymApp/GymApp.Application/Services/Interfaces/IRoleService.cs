using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task AssignRole(UserRole user);
    }
}
