
using GymApp.GymApp.Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace GymApp.GymApp.Application.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string receptor, string subject, string body)
        {
            var email = _configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");

            var password = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");

            var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");

            var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var smptclient = new SmtpClient(host, port);

            smptclient.UseDefaultCredentials = false;

            smptclient.EnableSsl = true;

            smptclient.Credentials = new NetworkCredential(email, password);

            var message = new MailMessage(email!,receptor,subject,body);

            await smptclient.SendMailAsync(message);

        }
    }
}
