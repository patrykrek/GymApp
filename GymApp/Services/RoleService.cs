using GymApp.Models;
using GymApp.Repositories.Interfaces;
using GymApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymApp.Services
{
    public class RoleService : IRoleService
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignRole(UserRole user)
        {
            var findUser = await _userManager.FindByEmailAsync(user.Email);

            if (findUser == null)
            {
                throw new ArgumentException($"User doesn't esxist");
            }

            var roleExists = await RoleExistsAsync(user.Roles);

            if (roleExists != null || roleExists.Count == user.Roles.Length)
            {
                var assignRole = await _userManager.AddToRolesAsync(findUser, user.Roles);
            }
            else
            {
                throw new ArgumentException($"Role doesn't exist");
            }


        }

        private async Task<List<string>> RoleExistsAsync(string[] roles)
        {
            var list = new List<string>();

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                {
                    list.Add(role);
                }
            }

            return list;
        }
    }
}
