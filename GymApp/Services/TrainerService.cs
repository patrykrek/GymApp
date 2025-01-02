using AutoMapper;
using GymApp.DTO;
using GymApp.Models;
using GymApp.Repositories.Interfaces;
using GymApp.Services.Interfaces;

namespace GymApp.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IGenericRepository<Trainer> _trainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(IGenericRepository<Trainer> trainerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _trainerRepository = trainerRepository;
        }

        public async Task AddTrainer(AddTrainersDTO trainer)
        {
            var newTrainer = new Trainer
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Bio = trainer.Bio,
                PhotoPath = trainer.PhotoPath,
            };

            await _trainerRepository.AddAsync(newTrainer);

        }

        public async Task<List<GetTrainersDTO>> GetTrainers()
        {
            var getDb = await _trainerRepository.GetAllAsync();

            var getTrainers = getDb.Select(t => _mapper.Map<GetTrainersDTO>(t)).ToList();

            return getTrainers;
        }

        public async Task<GetTrainersDTO> GetTrainerTrainings(int TrainerId)
        {
            var findTrainer = (await _trainerRepository.GetAllWithIncludeAsync(
                t => t.Id == TrainerId,
                t => t.Trainings))
                .FirstOrDefault();

            if (findTrainer == null)
            {
                throw new ArgumentException($"Trainer with ID '{TrainerId}' doesn't exist");
            }

            return _mapper.Map<GetTrainersDTO>(findTrainer);
                
                
                
                

        }
    }
}
