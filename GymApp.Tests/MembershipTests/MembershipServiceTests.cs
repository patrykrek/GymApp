using AutoMapper;
using GymApp.DTO;
using GymApp.Models;
using GymApp.Repositories.Interfaces;
using GymApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Tests.MembershipTests
{
    public class MembershipServiceTests
    {
        private readonly Mock<IGenericRepository<Membership>> _membershipRepoMock;
        private readonly Mock<IGenericRepository<UserMembership>> _usermembershipRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly MembershipService _membershipService;
       
        public MembershipServiceTests()
        {
            _membershipRepoMock = new Mock<IGenericRepository<Membership>>();
            _usermembershipRepoMock = new Mock<IGenericRepository<UserMembership>>();
            _mapperMock = new Mock<IMapper>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object,
                null, null, null, null, null, null, null, null);

            _membershipService = new MembershipService(
                _membershipRepoMock.Object,
                _usermembershipRepoMock.Object,
                _mapperMock.Object,
                _userManagerMock.Object);
        }

        [Fact]
        public async Task AddMembership_WhenCalled_ShouldAddMembership()
        {
            //arrange
            var membershipDTO = new AddMembershipDTO
            {
                Name = "Test",
                PricePerMonth = 150
            };
               
            //act

            await _membershipService.AddMembership(membershipDTO);

            //assert

            _membershipRepoMock.Verify(repo => repo.AddAsync(It.Is<Membership>(m => 
            m.Name == "Test" && m.PricePerMonth == 150)), Times.Once);
        }

        [Fact]
        public async Task GetAllMemberships_WhenCalled_ShouldReturnListOfMemberships()
        {
            //arrange
            var memberships = new List<Membership>
            {
                new Membership { Name = "Test", PricePerMonth = 150 },
                new Membership { Name = "Test2", PricePerMonth = 200 }
            };

            var membershipsDTO = new List<GetMembershipsDTO>
            {
                new GetMembershipsDTO { Name = "Test", PricePerMonth = 150},
                new GetMembershipsDTO {Name = "Test2", PricePerMonth= 200}
            };

            _membershipRepoMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(memberships);

            _mapperMock.Setup(m => m.Map<GetMembershipsDTO>(memberships[0]))
                .Returns(membershipsDTO[0]);

            _mapperMock.Setup(m => m.Map<GetMembershipsDTO>(memberships[1]))
                .Returns(membershipsDTO[1]);
            //act

            var result = await _membershipService.GetMemberships();

            //assert
            Assert.NotNull(result);
            Assert.Equal(membershipsDTO.Count, result.Count);
            Assert.Equal(membershipsDTO[0].Name, result[0].Name);
            Assert.Equal(membershipsDTO[0].PricePerMonth, result[0].PricePerMonth);
            Assert.Equal(membershipsDTO[1].Name, result[1].Name);
            Assert.Equal(membershipsDTO[1].PricePerMonth, result[1].PricePerMonth);

            _membershipRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<GetMembershipsDTO>(It.IsAny<Membership>()), Times.Exactly(memberships.Count));
        }

        


        
    }
}
