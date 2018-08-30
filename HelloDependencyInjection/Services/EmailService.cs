using HelloDependencyInjection.Models;

namespace HelloDependencyInjection.Services
{
    public class EmailService : IEmailService
    {
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
    }
}