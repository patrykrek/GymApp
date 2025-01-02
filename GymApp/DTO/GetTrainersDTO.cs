using GymApp.Models;

namespace GymApp.DTO
{
    public class GetTrainersDTO
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string PhotoPath { get; set; }

        public ICollection<Training> Trainings { get; set; }

    }

}
