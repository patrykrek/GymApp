using AutoMapper;
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Interfaces;
using GymApp.GymApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymApp.GymApp.Application.Services
{
    public class ReservationService : IReservationService
    {

        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IGenericRepository<Training> _trainingRepository;
        private readonly IGenericRepository<UserMembership> _umRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public ReservationService(IGenericRepository<Reservation> reservationRepository, IMapper mapper, UserManager<IdentityUser> userManager, IGenericRepository<Training> trainingRepository, IGenericRepository<UserMembership> umRepository)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _trainingRepository = trainingRepository;
            _umRepository = umRepository;
        }

        public async Task<Result> CreateReservation(int TrainingId, string UserId)
        {
            var findTraining = await _trainingRepository.GetByIdAsync(TrainingId);

            if (findTraining == null)
            {
                throw new ArgumentException($"Training with ID '{TrainingId}' doesn't exist");
            }

            var findUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == UserId);

            if (findUser == null)
            {
                throw new ArgumentException($"User doesn't exist");
            }

            var findUserMembership = await _umRepository.GetAllWithIncludeAsync(
                predicate: u => u.userId == UserId);


            if (findUserMembership == null || !findUserMembership.Any())
            {
                return new Result { Success = false };
            }

            var reservation = new Reservation
            {
                ReservationDate = DateTime.Now,
                TrainingId = TrainingId,
                userId = UserId,
            };

            await _reservationRepository.AddAsync(reservation);

            return new Result { Success = true };
        }

        public async Task<List<GetReservationsDTO>> GetReservations()
        {
            var getDb = await _reservationRepository.GetAllWithIncludeAsync(
                includeProperties: r => r.Training);

            var getReservations = getDb.Select(r => _mapper.Map<GetReservationsDTO>(r)).ToList();

            return getReservations;
        }

        public async Task<List<GetUsersReservationsDTO>> GetUserReservations(string userId)
        {
            var findUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (findUser == null)
            {
                throw new ArgumentException($"User doesn't exist");
            }

            var getUserDbReservations = await _reservationRepository.GetAllWithIncludeAsync(
                predicate: r => r.userId == userId,
                includeProperties: r => r.Training);

            var getUserReservations = getUserDbReservations.Select(ur => _mapper.Map<GetUsersReservationsDTO>(ur)).ToList();

            return getUserReservations;
        }
    }
}
