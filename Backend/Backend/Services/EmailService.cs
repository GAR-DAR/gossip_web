using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Backend.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendConfirmationEmailAsync(string to, string confirmationLink)
        {
            var smtpSettings = _config.GetSection("SmtpSettings");

            using var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"]))
            {
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = bool.Parse(smtpSettings["EnableSsl"])
            };

            var message = new MailMessage
            {
                From = new MailAddress(smtpSettings["Username"]),
                Subject = "Confirm your email",
                Body = $"Click the link to confirm your email: {confirmationLink}",
                IsBodyHtml = false
            };
            message.To.Add(to);

            await client.SendMailAsync(message);
        }
    }
}
