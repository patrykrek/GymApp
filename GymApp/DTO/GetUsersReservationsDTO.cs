using GymApp.Models;

namespace GymApp.DTO
{
    public class GetUsersReservationsDTO
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }

       
    }
}
