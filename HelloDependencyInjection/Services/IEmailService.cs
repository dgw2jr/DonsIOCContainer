namespace HelloDependencyInjection.Services
{
    public interface IEmailService
    {
        string Create(string toAddress, string fromAddress, string subject, string body);
    }
}