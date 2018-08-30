using HelloDependencyInjection.Models;

namespace HelloDependencyInjection.Services
{
    public interface IEmailService
    {
        EmailContentViewModel Create(string toAddress, string fromAddress, string subject, string body);
    }
}