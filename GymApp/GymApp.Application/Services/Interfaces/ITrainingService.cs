using GymApp.GymApp.Application.DTO;

namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface ITrainingService
    {
        Task AddTraining(AddTrainingsDTO training);
        Task<List<GetTrainingsDTO>> GetAllTrainings();
        Task DeleteTraining(DeleteTrainingDTO training);
        Task<UpdateTrainingsDTO> GetTrainingForEdit(int TrainingId);
        Task EditTraining(UpdateTrainingsDTO training);
    }
}
