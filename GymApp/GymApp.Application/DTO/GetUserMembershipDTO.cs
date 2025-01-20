using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.DTO
{
    public class GetUserMembershipDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
