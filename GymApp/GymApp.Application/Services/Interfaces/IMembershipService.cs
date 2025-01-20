using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IMembershipService
    {
        Task AddMembership(AddMembershipDTO membership);
        Task BuyMembership(int membershipId, string userId);
        Task<List<GetMembershipsDTO>> GetMemberships();
        Task<Result> CheckUserMembership(string userId);
        Task<GetUserMembershipDTO> GetUserMembership(string userId);
    }
}
