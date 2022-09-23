using RegisterModule.Interfaces;
using System.Net.Mail;
using RegisterModule.Models;
using System.Net;


namespace RegisterModule.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration config)
        {
            this._configuration = config;
        }

        public void Send(string to,string name)
        {
            string email = _configuration.GetValue<string>("MailConfig:SmtpUser");
            string emailFrom = _configuration.GetValue<string>("MailConfig:SmtpFrom");
            string password = _configuration.GetValue<string>("MailConfig:SmtpPass");

            var senderEmail = new MailAddress(email, emailFrom);
            var receiver = new MailAddress(to, "Receiver");
           
            var sub = "Registered Successfully!";
            var body = $"Dear "+name+",\nYou application registered successfully on portal.\nwe will contact you soon!\n\nThanks,\nTeam support";

            var smtp = new SmtpClient
            {
                Host = _configuration.GetValue<string>("MailConfig:SmtpHost"),
                Port = _configuration.GetValue<int>("MailConfig:SmtpPort"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (var mess = new MailMessage(senderEmail, receiver)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }

        }
        
    }
}
