using GymApp.GymApp.Application.Services;
using GymApp.GymApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Tests.Role_Tests
{
    public class RoleServiceTests
    {
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly RoleService _roleService;

        public RoleServiceTests()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(
            Mock.Of<IUserStore<IdentityUser>>(),
            null, null, null, null, null, null, null, null);

            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null, null, null, null);

            _roleService = new RoleService(_userManagerMock.Object, _roleManagerMock.Object);
        }

        [Fact]
        public async Task AssignRole_WhenUserAndRoleExist_ShouldAssignRole()
        {
            //arrange
            var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com" };

            var userrole = new UserRole {Email = "user@test.com" ,Roles = new string[] { "User"} };

            _userManagerMock.Setup(manager => manager.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _roleManagerMock.Setup(manager => manager.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            _userManagerMock.Setup(manager => manager.AddToRolesAsync(user, userrole.Roles))
                .ReturnsAsync(IdentityResult.Success);

            //act

            await _roleService.AssignRole(userrole);

            //assert

            _userManagerMock.Verify(manager => manager.AddToRolesAsync(user, userrole.Roles), Times.Once);

        }

        [Fact]
        public async Task AssignRole_WhenUserDoesNotExist_ShouldThrowException()
        {
            //arrange
            var userrole = new UserRole { Email = "user@test.com"};

            _userManagerMock.Setup(manager => manager.FindByEmailAsync(userrole.Email))
                .ReturnsAsync((IdentityUser)null);

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _roleService.AssignRole(userrole));

            //assert

            Assert.Equal($"User doesn't exist", exception.Message);
        }

        [Fact]
        public async Task AssignRole_WhenRoleDoesNotExist_ShouldThrowException()
        {
            //arrange
            var userrole = new UserRole { Email = "user@test.com" ,Roles = new string[] { "test" } };

            var user = new IdentityUser { Email = "user@test.com", UserName = "user@test.com" };

            _userManagerMock.Setup(manager => manager.FindByEmailAsync(userrole.Email))
                .ReturnsAsync(user);

            _roleManagerMock.Setup(manager => manager.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _roleService.AssignRole(userrole));

            //assert

            Assert.Equal("Role doesn't exist", exception.Message);
        }
    }
    
}
