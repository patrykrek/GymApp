using AutoMapper;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Interfaces;
using GymApp.GymApp.Domain.Models;

namespace GymApp.GymApp.Application.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IGenericRepository<Training> _trainingRepository;
        private readonly IGenericRepository<Trainer> _trainerRepository;
        private readonly IMapper _mapper;
        public TrainingService(IGenericRepository<Training> trainingRepository, IGenericRepository<Trainer> trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
            _trainingRepository = trainingRepository;
        }

        public async Task AddTraining(AddTrainingsDTO training)
        {
            var trainerExists = await _trainerRepository.ExistsAsync(training.TrainerId);

            if (!trainerExists)
            {
                throw new ArgumentException($"Trainer doesn't exist");
            }

            var newTraining = new Training
            {
                Name = training.Name,
                Description = training.Description,
                StartDate = training.StartDate,
                Duration = training.Duration,
                TrainerId = training.TrainerId,
            };

            await _trainingRepository.AddAsync(newTraining);


        }

        public async Task DeleteTraining(DeleteTrainingDTO training)
        {
            var trainingExists = await _trainingRepository.ExistsAsync(training.Id);

            if (!trainingExists)
            {
                throw new ArgumentException($"Training with ID '{training.Id}' doesn't exist");
            }

            await _trainingRepository.DeleteAsync(training.Id);
        }

        public async Task<List<GetTrainingsDTO>> GetAllTrainings()
        {
            var getDb = await _trainingRepository.GetAllWithIncludeAsync(
                includeProperties: t => t.Trainer
                );

            var getTrainings = getDb.Select(t => _mapper.Map<GetTrainingsDTO>(t)).ToList();

            return getTrainings;
        }

        public async Task<UpdateTrainingsDTO> GetTrainingForEdit(int TrainingId)
        {
            var training = await _trainingRepository.GetAllWithIncludeAsync(
                predicate: t => t.Id == TrainingId,
                includeProperties: t => t.Trainer);

            var foundTraining = training.FirstOrDefault();

            if (foundTraining == null)
            {
                throw new ArgumentException($"Training with ID '{TrainingId}' doesn't exist");
            }

            return new UpdateTrainingsDTO
            {
                Id = foundTraining.Id,
                Name = foundTraining.Name,
                Description = foundTraining.Description,
                StartDate = foundTraining.StartDate,
                Duration = foundTraining.Duration,
                TrainerId = foundTraining.TrainerId,
            };

        }
        public async Task EditTraining(UpdateTrainingsDTO training)
        {
            var findTraining = await _trainingRepository.GetByIdAsync(training.Id);

            if (findTraining == null)
            {
                throw new ArgumentException($"Training with ID '{training.Id}' doesn't exist");
            }

            findTraining.Name = training.Name;
            findTraining.Description = training.Description;
            findTraining.StartDate = training.StartDate;
            findTraining.Duration = training.Duration;
            findTraining.TrainerId = training.TrainerId;

            await _trainingRepository.EditAsync(findTraining);
        }
    }
}
