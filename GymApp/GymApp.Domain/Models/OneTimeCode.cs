namespace GymApp.GymApp.Domain.Models
{
    public class OneTimeCode
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsUsed { get; set; }
        public User User { get; set; }

    }
}
