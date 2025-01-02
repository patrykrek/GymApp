using GymApp.DTO;
using GymApp.Models;
using GymApp.Models.ViewModels;
using GymApp.Repositories.Interfaces;
using GymApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Result> Register(RegisterViewModel register)
        {
            var findUser = await _userManager.FindByEmailAsync(register.Email);

            if (findUser != null)
            {
                return new Result { Success = false };
            }

            var newUser = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Email
            };

            var result = await _userManager.CreateAsync(newUser, register.Password);

            if (result.Succeeded)
            {
                return new Result { Success = true };
            }
            else
            {
                return new Result { Success = false };
            }
        }
        public async Task<Result> Login(LoginViewModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                return new Result { Success = true };
            }
            else
            {
                return new Result { Success = false };
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task VerifyEmail(VerifyEmailDTO model)
        {
            var findUser = await _userManager.FindByEmailAsync(model.Email);

            if (findUser == null)
            {
                throw new ArgumentException($"User with that email doesn't exist");
            }
        }

        public async Task<Result> ChangePassword(ChangePasswordDTO request)
        {
            var findUser = await _userManager.FindByEmailAsync(request.Email);

            if (findUser == null)
            {
                return new Result { Success = false };
            }

            var result = await _userManager.RemovePasswordAsync(findUser);

            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(findUser, request.NewPassword);
            }

            return new Result { Success = true };
        }
    }
}
