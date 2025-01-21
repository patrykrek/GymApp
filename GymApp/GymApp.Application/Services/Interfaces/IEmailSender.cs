namespace GymApp.GymApp.Application.Services.Interfaces
{
    public interface IEmailSender 
    {
        Task SendEmail(string receptor, string subject, string body);
    }
}
