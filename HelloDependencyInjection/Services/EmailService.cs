using System.Net.Mail;
using HelloDependencyInjection.Models;

namespace HelloDependencyInjection.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpClientWrapper _smtpClientWrapper;

        public EmailService(ISmtpClientWrapper smtpClientWrapper)
        {
            _smtpClientWrapper = smtpClientWrapper;
        }

        public EmailContentViewModel Create(string toAddress, string fromAddress, string subject, string body)
        {
            var result = new EmailContentViewModel
            {
                Content = body,
                To = toAddress,
                From = fromAddress,
                Subject = subject
            };

            return result;
        }

        public void Send(EmailContentViewModel content)
        {
            var mailMessage = new MailMessage(content.From, content.To, content.Subject, content.Content);
            _smtpClientWrapper.Send(mailMessage);
        }
    }
}