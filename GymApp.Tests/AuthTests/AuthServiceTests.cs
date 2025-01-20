
using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Services;
using GymApp.GymApp.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Tests.AuthTests
{
    public class AuthServiceTests
    {
        private readonly Mock<SignInManager<IdentityUser>> _signinManagerMock;
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            // Setup SignInManager mock
            var contextAccessorMock = new Mock<IHttpContextAccessor>();
            var claimsFactoryMock = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();
            _signinManagerMock = new Mock<SignInManager<IdentityUser>>(
                _userManagerMock.Object,
                contextAccessorMock.Object,
                claimsFactoryMock.Object,
                null,
                null,
                null,
                null);

            _authService = new AuthService(
               _signinManagerMock.Object,
                _userManagerMock.Object);                
        }

        [Fact]
        public async Task Register_WhenUserDoesNotExist_ShouldCreateAccount()
        {
            //arrange
            var register = new RegisterViewModel
            {
                Email = "test@test.com",
                Password = "test",
                
            };

            _userManagerMock.Setup(mng => mng.FindByEmailAsync(register.Email))
                .ReturnsAsync((IdentityUser)null);

            _userManagerMock.Setup(mng => mng.CreateAsync(It.IsAny<IdentityUser>(), register.Password))
                .ReturnsAsync(IdentityResult.Success);

            //act

            var result = await _authService.Register(register);

            //assert
            Assert.True(result.Success);

            
        }

        [Fact]
        public async Task Register_WhenUserExist_ShouldReturnFalse()
        {
            //arrange
            var register = new RegisterViewModel
            {
                Email = "test@test.com",
                Password = "test"
            };

            _userManagerMock.Setup(mng => mng.FindByEmailAsync(register.Email))
                .ReturnsAsync(new IdentityUser { Email = "test@test.com"});


            //act

            var result = await _authService.Register(register);

            //assert

            Assert.False(result.Success);
        }

        [Fact]
        public async Task Login_WhenEverythingIsCorrect_ShouldReturnTrue()
        {
            //arrange
            var login = new LoginViewModel
            {
                Email = "test@test.com",
                Password = "test",
                RememberMe = false
            };

            

            _signinManagerMock.Setup(mng => mng.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false))
                .ReturnsAsync(SignInResult.Success);


            //act

            var result = await _authService.Login(login);

            //assert

            Assert.True(result.Success);
        }

        [Fact]
        public async Task Login_WhenPasswordIsIncorrect_ShouldReturnFalse()
        {
            //arrange
            var login = new LoginViewModel
            {
                Email = "test@test.com",
                Password = "test",
                RememberMe = false
            };

            _signinManagerMock.Setup(mng => mng.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false))
                .ReturnsAsync(SignInResult.Failed);

            //act

            var result = await _authService.Login(login);

            //assert

            Assert.False(result.Success);
        }

        [Fact]
        public async Task Logout_WhenCalled_ShouldLogoutUser()
        {
            //act
            await _authService.Logout();

            //assert
            _signinManagerMock.Verify(mng => mng.SignOutAsync(), Times.Once);
        }

        [Fact]
        public async Task ChangePassword_WhenUserExist_ShouldChangeHisPassword()
        {
            //arrange
            var request = new ChangePasswordDTO
            {
                Email = "test@test.com",
                NewPassword = "test"
            };

            var user = new IdentityUser
            {
                Email = "test@test.com"
            };

            _userManagerMock.Setup(mng => mng.FindByEmailAsync(request.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(mng => mng.RemovePasswordAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(mng => mng.AddPasswordAsync(user, request.NewPassword))
                .ReturnsAsync(IdentityResult.Success);

            //act
            var result = await _authService.ChangePassword(request);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task ChangePassword_WhenUserDoesNotExist_ShouldReturnFalse()
        {
            //arrange

            var request = new ChangePasswordDTO
            {
                Email = "test@test.com",
                NewPassword = "test"
            };
         
            _userManagerMock.Setup(mng => mng.FindByEmailAsync(request.Email))
                .ReturnsAsync((IdentityUser)null);

           

            //act

            var result = await _authService.ChangePassword(request);

            //assert

            Assert.False(result.Success);

        }

        [Fact]
        public async Task VerifyEmail_WhenUserDoesNotExist_ShouldThrowException()
        {
            //arrange
            var model = new VerifyEmailDTO
            {
                Email = "test@test.com"
            };

            _userManagerMock.Setup(mng => mng.FindByEmailAsync(model.Email))
                .ReturnsAsync((IdentityUser)null);

            //act

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _authService.VerifyEmail(model));

            //assert

            Assert.Equal($"User with that email doesn't exist", exception.Message);
        }

       
        
    }
    
}
