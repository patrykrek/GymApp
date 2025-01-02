using GymApp.DTO;

namespace GymApp.Services.Interfaces
{
    public interface ITrainerService
    {
        Task AddTrainer(AddTrainersDTO trainer);
        Task<List<GetTrainersDTO>> GetTrainers();
        Task<GetTrainersDTO> GetTrainerTrainings(int TrainerId);
    }
}
