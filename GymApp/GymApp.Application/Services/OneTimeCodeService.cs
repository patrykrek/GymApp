using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.CodeGenerator;
using GymApp.GymApp.Domain.Interfaces;
using GymApp.GymApp.Domain.Models;
using System.Security.Cryptography;

namespace GymApp.GymApp.Application.Services
{
    public class OneTimeCodeService : IOneTimeCodeService
    {
        private readonly IGenericRepository<OneTimeCode> _repository;

        public OneTimeCodeService(IGenericRepository<OneTimeCode> repository)
        {
            _repository = repository;
        }

        public async Task<int> GenerateAndSaveCode(string UserId)
        {
            int randomCode = CodeGenerator.GenerateSixDigitsCode();

            var code = new OneTimeCode
            {
                UserId = UserId,
                Code = randomCode,
                CreatedAt = DateTime.UtcNow,
                IsUsed = false
            };

            await _repository.AddAsync(code);

            return randomCode;
           
        }

        public async Task<bool> ValidateCode(string UserId, int Code)
        {
            var code = await _repository.GetSingleAsync(c =>
            c.UserId == UserId &&
            c.Code == Code &&
            !c.IsUsed &&
            c.CreatedAt > DateTime.UtcNow.AddMinutes(-5));

            if(code != null)
            {
                code.IsUsed = true;

                await _repository.EditAsync(code);

                return true;
            }
            return false;
        }
    }
}
