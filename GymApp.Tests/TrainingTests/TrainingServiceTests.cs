using AutoMapper;
using GymApp.DTO;
using GymApp.Models;
using GymApp.Repositories;
using GymApp.Repositories.Interfaces;
using GymApp.Services;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace GymApp.Tests.TrainingTests
{
    public class TrainingServiceTests
    {
        private readonly Mock<IGenericRepository<Trainer>> _trainerRepoMock;
        private readonly Mock<IGenericRepository<Training>> _trainingRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TrainingService _trainingService;

        public TrainingServiceTests()
        {
            _trainerRepoMock = new Mock<IGenericRepository<Trainer>>();

            _trainingRepoMock = new Mock<IGenericRepository<Training>>();

            _mapperMock = new Mock<IMapper>();

            _trainingService = new TrainingService(
                _trainingRepoMock.Object,
                _trainerRepoMock.Object,
                _mapperMock.Object);
            
        }



        [Fact]
        public async Task AddTrainingTest_WhenTrainerExists_ShouldAddTraining()
        {
            //arrange
            var trainingDTO = new AddTrainingsDTO
            {
                Name = "Test",
                Description = "Test2",
                StartDate = DateTime.Now,
                Duration = 60,
                TrainerId = 1
            };
       
            _trainerRepoMock.Setup(repo => repo.ExistsAsync(trainingDTO.TrainerId))
                .ReturnsAsync(true);

            _trainingRepoMock.Setup(repo => repo.AddAsync(It.IsAny<Training>()))
                .Returns(Task.CompletedTask);            

            //act

            await _trainingService.AddTraining(trainingDTO);
            
            //assert

            _trainingRepoMock.Verify(repo => repo.AddAsync(It.Is<Training>(t =>
            t.Name == trainingDTO.Name &&
            t.Description == trainingDTO.Description &&
            t.StartDate == trainingDTO.StartDate &&
            t.Duration == trainingDTO.Duration &&
            t.TrainerId == trainingDTO.TrainerId)), Times.Once());              
        }

        [Fact]
        public async Task AddTraining_WhenTrainerDoesNotExist_ShouldThrowException()
        {
            //arrange
            var trainingDTO = new AddTrainingsDTO
            {
                Name = "Test",
                Description = "Test2",
                StartDate = DateTime.Now,
                Duration = 60,
                TrainerId = 100
            };

            _trainerRepoMock.Setup(repo => repo.ExistsAsync(trainingDTO.TrainerId))
                .ReturnsAsync(false);
           
            //act 

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _trainingService.AddTraining(trainingDTO));

            //assert

            Assert.Equal("Trainer doesn't exist", exception.Message);

            
        }

        [Fact]
        public async Task DeleteTraining_WhenTrainingExists_ShouldDeleteTraining()
        {
            //arrange
            var trainingDTO = new DeleteTrainingDTO
            {
                Id = 1,
            };
           

            _trainingRepoMock.Setup(repo => repo.ExistsAsync(trainingDTO.Id))
                .ReturnsAsync(true);

            _trainingRepoMock.Setup(repo => repo.DeleteAsync(trainingDTO.Id))
                .Returns(Task.CompletedTask);


            //act
            await _trainingService.DeleteTraining(trainingDTO);
            //assert

            _trainingRepoMock.Verify(repo => repo.DeleteAsync(trainingDTO.Id), Times.Once);
        }

        [Fact]
        public async Task DeleteTraining_WhenTrainingDoesNotExist_ShouldThrowException()
        {
            //arrange

            var trainingDTO = new DeleteTrainingDTO
            {
                Id = 100,
            };

            _trainingRepoMock.Setup(repo => repo.ExistsAsync(trainingDTO.Id))
                .ReturnsAsync(false);

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _trainingService.DeleteTraining(trainingDTO));

            //assert

            Assert.Equal($"Training with ID '{trainingDTO.Id}' doesn't exist", exception.Message);
        }

        [Fact]
        public async Task GetAllTrainings_WhenCalled_ShouldReturnTrainings()
        {
            //arrange
            var trainings = new List<Training>
            {
                new Training {Id = 1, Name = "test", Description = "test1", Duration = 60, StartDate = DateTime.Now, TrainerId = 1},
                new Training {Id = 2, Name = "test2", Description = "test2", Duration = 60, StartDate = DateTime.Now, TrainerId = 2}
            };

            var trainingDTOS = new List<GetTrainingsDTO>
            {
                new GetTrainingsDTO{Id = 1, Name = "test", Description = "test1", Duration = 60, StartDate = DateTime.Now, TrainerId = 1},
                new GetTrainingsDTO{Id = 2, Name = "test2", Description = "test1", Duration = 60, StartDate = DateTime.Now, TrainerId = 2}
            };

            _trainingRepoMock.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training, bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>())).ReturnsAsync(trainings);

            _mapperMock.Setup(mapper => mapper.Map<GetTrainingsDTO>(trainings[0]))
                .Returns(trainingDTOS[0]);

            _mapperMock.Setup(mapper => mapper.Map<GetTrainingsDTO>(trainings[1]))
                .Returns(trainingDTOS[1]);

            //act

            var result = await _trainingService.GetAllTrainings();

            //assert

            Assert.NotNull(result);
            Assert.Equal(result.Count, trainingDTOS.Count);
            Assert.Equal(result[0].Name, trainingDTOS[0].Name);
            Assert.Equal(result[1].Name, trainingDTOS[1].Name);

            _trainingRepoMock.Verify(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training, bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>()), Times.Once());

            _mapperMock.Verify(m => m.Map<GetTrainingsDTO>(It.IsAny<Training>()), Times.Exactly(trainings.Count));
        }

        [Fact]
        public async Task EditTraining_WhenTrainingExist_ShouldEditTraining()
        {
            //arrange
            var trainingForEdit = new Training
            {
                Id = 1,
                Name = "test",
                Description = "test2",
                Duration = 60,
                StartDate = DateTime.Now,
                TrainerId = 1,
            };

            var updateTraining = new UpdateTrainingsDTO
            {
                Id = 1,
                Name = "test1",
                Description = "test",
                Duration = 60,
                StartDate = DateTime.Now,
                TrainerId = 2
            };

            _trainingRepoMock.Setup(repo => repo.GetByIdAsync(trainingForEdit.Id))
                .ReturnsAsync(trainingForEdit);

            _trainingRepoMock.Setup(repo => repo.EditAsync(It.IsAny<Training>()))
                .Returns(Task.CompletedTask);

            //act

            await _trainingService.EditTraining(updateTraining);

            //assert

            Assert.Equal(updateTraining.Name, trainingForEdit.Name);
            Assert.Equal(updateTraining.Description, trainingForEdit.Description);
            Assert.Equal(updateTraining.Duration, trainingForEdit.Duration);
            Assert.Equal(updateTraining.StartDate, trainingForEdit.StartDate);
            Assert.Equal(updateTraining.TrainerId, trainingForEdit.TrainerId);

            _trainingRepoMock.Verify(repo => repo.GetByIdAsync(trainingForEdit.Id), Times.Once);

            _trainingRepoMock.Verify(repo => repo.EditAsync(It.Is<Training>(t => //sprawdza czy wywolana metoda jest obiektem klasy Training oraz sprawdza okreslone kryteria
            t.Id == updateTraining.Id &&
            t.Name == updateTraining.Name &&
            t.Description == updateTraining.Description &&
            t.Duration == updateTraining.Duration && 
            t.StartDate == updateTraining.StartDate &&
            t.TrainerId == updateTraining.TrainerId
            )),Times.Once);
        }

        [Fact]
        public async Task EditTraining_WhenTrainingDoesNotExist_ShouldThrowException()
        {
            //arrange

            
            var updateTraining = new UpdateTrainingsDTO
            {
                Id = 1,
                Name = "test1",
                Description = "test",
                Duration = 60,
                StartDate = DateTime.Now,
                TrainerId = 2
            };

            _trainingRepoMock.Setup(repo => repo.GetByIdAsync(updateTraining.Id))
                .ReturnsAsync((Training)null);

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _trainingService.EditTraining(updateTraining));

            //assert

            Assert.Equal($"Training with ID '{updateTraining.Id}' doesn't exist", exception.Message);

            _trainingRepoMock.Verify(repo => repo.GetByIdAsync(updateTraining.Id), Times.Once);
            _trainingRepoMock.Verify(repo => repo.EditAsync(It.IsAny<Training>()), Times.Never);
        }

        [Fact]
        public async Task GetTrainingForEdit_WhenTrainingExists_ShouldReturnUpdateTrainingsDTO()
        {
            //arrange
            var training = new Training
            {
                Id = 1,
                Name = "test1",
                Description = "test",
                Duration = 60,
                StartDate = DateTime.Now,
                TrainerId = 1
            };

            var expectedDTO = new UpdateTrainingsDTO
            {
                Id = training.Id,
                Name = training.Name,
                Description = training.Description,
                Duration = training.Duration,
                StartDate = training.StartDate,
                TrainerId = training.TrainerId
            };

            _trainingRepoMock.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training, bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>())).ReturnsAsync(new List<Training> { training});

            //act

            var result = await _trainingService.GetTrainingForEdit(training.Id);


            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedDTO.Id, result.Id);
            Assert.Equal(expectedDTO.Name, result.Name);
            Assert.Equal(expectedDTO.Description, result.Description);
            Assert.Equal(expectedDTO.Duration, result.Duration);
            Assert.Equal(expectedDTO.StartDate, result.StartDate);
            Assert.Equal(expectedDTO.TrainerId, result.TrainerId);

            _trainingRepoMock.Verify(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training,bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>()), Times.Once());   



        }

        [Fact]
        public async Task GetTrainingForEdit_WhenTrainingDoesNotExist_ShouldThrowException()
        {
            //arrange
            var trainingId = 1;

            _trainingRepoMock.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training, bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>()))
                .ReturnsAsync(new List<Training>());

            //act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _trainingService.GetTrainingForEdit(trainingId));
            //assert

            Assert.Equal($"Training with ID '{trainingId}' doesn't exist", exception.Message);

            _trainingRepoMock.Verify(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Training, bool>>>(),
                It.IsAny<Expression<Func<Training, object>>[]>()), Times.Once());
        }
    }
}