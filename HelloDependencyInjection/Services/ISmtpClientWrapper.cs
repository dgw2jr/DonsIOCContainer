using System.Net.Mail;

namespace HelloDependencyInjection.Services
{
    public interface ISmtpClientWrapper
    {
        void Send(MailMessage mailMessage);
    }
}