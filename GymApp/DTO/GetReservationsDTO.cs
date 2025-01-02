using GymApp.Models;

namespace GymApp.DTO
{
    public class GetReservationsDTO
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public string userId { get; set; }
        
    }
}
