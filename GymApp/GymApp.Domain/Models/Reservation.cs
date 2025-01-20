namespace GymApp.GymApp.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public string userId { get; set; }
        public User User { get; set; }
    }
}
