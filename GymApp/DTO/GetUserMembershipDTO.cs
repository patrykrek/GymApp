using GymApp.Models;

namespace GymApp.DTO
{
    public class GetUserMembershipDTO
    {
        public int Id { get; set; }       
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
