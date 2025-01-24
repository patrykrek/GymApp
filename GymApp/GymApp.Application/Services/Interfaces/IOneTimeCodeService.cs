namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IOneTimeCodeService
    {
        Task<int> GenerateAndSaveCode(string UserId);
        Task<bool> ValidateCode(string UserId, int Code);
    }
}
