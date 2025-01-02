using GymApp.Models;

namespace GymApp.Services.Interfaces
{
    public interface IRoleService
    {
        Task AssignRole(UserRole user);
    }
}
