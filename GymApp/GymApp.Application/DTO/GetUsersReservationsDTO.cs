using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.DTO
{
    public class GetUsersReservationsDTO
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }


    }
}
