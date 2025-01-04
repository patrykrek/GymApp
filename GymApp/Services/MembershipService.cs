using AutoMapper;
using GymApp.DTO;
using GymApp.Models;
using GymApp.Repositories.Interfaces;
using GymApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IGenericRepository<Membership> _membershipRepository;
        private readonly IGenericRepository<UserMembership> _usermembershipRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public MembershipService(IGenericRepository<Membership> membershipRepository, IGenericRepository<UserMembership> usermembershipRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _membershipRepository = membershipRepository;
            _usermembershipRepository = usermembershipRepository;
            _userManager = userManager;
        }

        public async Task AddMembership(AddMembershipDTO membership)
        {
            var newMembership = new Membership
            {
                Name = membership.Name,
                PricePerMonth = membership.PricePerMonth,
            };

            await _membershipRepository.AddAsync(newMembership);

        }

        public async Task BuyMembership(int membershipId, string userId)
        {
            var findMembership = await _membershipRepository.GetByIdAsync(membershipId);

            if (findMembership == null)
            {
                throw new ArgumentException($"Membership with ID '{membershipId}' doesn't exist");
            }

            var findUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if(findUser == null)
            {
                throw new ArgumentException($"User doesn't exist");
            }

            if(findMembership.Name == "Monthly")
            {
                var userMembership = new UserMembership
                {
                    MembershipId = membershipId,
                    userId = userId,
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(30)


                };
                await _usermembershipRepository.AddAsync(userMembership);
            }

            if(findMembership.Name == "Yearly")
            {
                var userMembership = new UserMembership
                {
                    MembershipId = membershipId,
                    userId = userId,
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(365)
                };
                await _usermembershipRepository.AddAsync(userMembership);
            }

           

            

        }

        public async Task<List<GetMembershipsDTO>> GetMemberships()
        {
            var getDb = await _membershipRepository.GetAllAsync();

            var getMemberships = getDb.Select(m => _mapper.Map<GetMembershipsDTO>(m)).ToList();

            return getMemberships;
        }

        public async Task<Result> CheckUserMembership(string userId)
        {
            var findUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (findUser == null)
            {
                throw new ArgumentException($"User with that ID doesn't exist");
            }

            var userMemberships = (await _usermembershipRepository.GetAllWithIncludeAsync(
                predicate: um => um.userId == userId,
                includeProperties: um => um.Membership))
                .FirstOrDefault();
                
                

            if (userMemberships == null)
            {
                return new Result { Success = false };
            }

            return new Result { Success = true };

        }

        public async Task<GetUserMembershipDTO> GetUserMembership(string userId)
        {
            var findUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (findUser == null)
            {
                throw new ArgumentException($"User with that ID doesn't exist");
            }

            var getuserMembership = await _usermembershipRepository.GetAllWithIncludeAsync(
                um => um.userId == userId,
                um => um.Membership);  

            var usermembership = getuserMembership.FirstOrDefault();

            return _mapper.Map<GetUserMembershipDTO>(usermembership);
                       

        }
    }
}
