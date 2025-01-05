using AutoMapper;
using GymApp.DTO;
using GymApp.Models;
using GymApp.Repositories.Interfaces;
using GymApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Tests.TrainerTests
{
    public class TrainerServiceTest
    {
        private readonly Mock<IGenericRepository<Trainer>> _trainerMockRepo;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TrainerService _trainerService;

        public TrainerServiceTest()
        {
            _trainerMockRepo = new Mock<IGenericRepository<Trainer>>();
            _mapperMock = new Mock<IMapper>();

            _trainerService = new TrainerService(_trainerMockRepo.Object, _mapperMock.Object);

        }

        [Fact]
        public async Task GetAllTrainers_WhenCalled_ShouldReturnTrainers()
        {
            //arrange
            var trainers = new List<Trainer>
            {
                new Trainer{Id = 1, FirstName = "test1", LastName = "test1", Bio = "Bio1", PhotoPath = "/path/photo1.png"},
                new Trainer{Id = 2, FirstName = "test2", LastName = "test2", Bio = "Bio2", PhotoPath = "/path/photo2.png"}
            };

            var trainersDTO = new List<GetTrainersDTO>
            {
                new GetTrainersDTO {Id = 1, FirstName = "test1", LastName = "test1", Bio = "Bio1", PhotoPath = "/path/photo1.png"},
                new GetTrainersDTO {Id = 2, FirstName = "test2", LastName = "test2", Bio = "Bio2", PhotoPath = "/path/photo2.png"},
            };

            _mapperMock.Setup(m => m.Map<GetTrainersDTO>(trainers[0]))
                .Returns(trainersDTO[0]);

            _mapperMock.Setup(m => m.Map<GetTrainersDTO>(trainers[1]))
                .Returns(trainersDTO[1]);

            _trainerMockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(trainers);

            //act

            var result = await _trainerService.GetTrainers();

            //assert
            Assert.NotNull(result);
            Assert.Equal(trainersDTO.Count, result.Count);
            Assert.Equal(trainersDTO[0], result[0]);
            Assert.Equal(trainersDTO[1], result[1]);


        }

        [Fact]
        public async Task AddTrainers_WhenCalled_ShouldAddTrainers()
        {
            //arrange
            var addtrainer = new AddTrainersDTO
            {
                FirstName = "test1",
                LastName = "test2",
                Bio = "Bio",
                PhotoPath = "/path/photo.png"
            };

            _trainerMockRepo.Setup(repo => repo.AddAsync(It.IsAny<Trainer>()))
                .Returns(Task.CompletedTask);


            //act

            await _trainerService.AddTrainer(addtrainer);

            //assert

            _trainerMockRepo.Verify(repo => repo.AddAsync(It.Is<Trainer>(t =>
            t.FirstName == addtrainer.FirstName &&
            t.LastName == addtrainer.LastName &&
            t.Bio == addtrainer.Bio &&
            t.PhotoPath == addtrainer.PhotoPath)), Times.Once);
        }

        [Fact]
        public async Task GetTrainerTrainings_WhenTrainerExist_ShouldReturnTrainerDTO()
        {
            //arrange
            var trainerId = 1;

            var trainer = new Trainer
            {
                FirstName = "test1",
                LastName = "test2",
                Bio = "Bio",
                PhotoPath = "/path/photo.png",
                Trainings = new List<Training>
                {
                    new Training {Id = 1,Name = "Name", Description = "Description", Duration = 60, StartDate = DateTime.Now, TrainerId = 1}
                }
                
            };

            var trainerDTO = new GetTrainersDTO
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Bio = trainer.Bio,
                PhotoPath = trainer.PhotoPath,        
                Trainings = trainer.Trainings
            };

            _trainerMockRepo.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Trainer, bool>>>(),
                It.IsAny<Expression<Func<Trainer, object>>[]>()))
                .ReturnsAsync(new List<Trainer> { trainer });

            _mapperMock.Setup(m => m.Map<GetTrainersDTO>(trainer)).Returns(trainerDTO);

            //act

            var result = await _trainerService.GetTrainerTrainings(trainerId);

            //assert
            Assert.NotNull(result);
            Assert.Equal(trainerDTO.FirstName, result.FirstName);
            Assert.Equal(trainerDTO.LastName, result.LastName);
            Assert.Equal(trainerDTO.Trainings.Count, result.Trainings.Count);
        }

        [Fact]
        public async Task GetTrainerTrainings_WhenTrainerDoesNotExist_ShouldThrowException()
        {
            //arrange
            var trainerId = 1;

            _trainerMockRepo.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Trainer, bool>>>(),
                It.IsAny<Expression<Func<Trainer, object>>[]>()))
                .ReturnsAsync(new List<Trainer>());

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _trainerService.GetTrainerTrainings(trainerId));

            //assert
            Assert.Equal($"Trainer with ID '{trainerId}' doesn't exist", exception.Message);

            _mapperMock.Verify(m => m.Map<GetTrainersDTO>(It.IsAny<Trainer>()), Times.Never);
        }

    }
}
