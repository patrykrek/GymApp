using GymApp.DTO;
using GymApp.Models;

namespace GymApp.Services.Interfaces
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
