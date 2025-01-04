namespace GymApp.Models
{
    public class UserMembership
    {
        public int Id { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string userId { get; set; }
        public User User { get; set; }

        public int MembershipId { get; set; }
        public Membership Membership { get; set; }

    }
}
