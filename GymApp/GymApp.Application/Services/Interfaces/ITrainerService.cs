using GymApp.GymApp.Application.DTO;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface ITrainerService
    {
        Task AddTrainer(AddTrainersDTO trainer);
        Task<List<GetTrainersDTO>> GetTrainers();
        Task<GetTrainersDTO> GetTrainerTrainings(int TrainerId);
    }
}
