using System;
using System.Configuration;
using System.Net.Mail;

namespace HelloDependencyInjection.Services
{
    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        public SmtpClientWrapper()
        {
            Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"]);
            Server = ConfigurationManager.AppSettings["EmailServer"];
        }

        public string Server { get; set; }

        public int Port { get; }

        public void Send(MailMessage mailMessage)
        {
            using (var client = new SmtpClient(Server, Port))
            {
                client.Send(mailMessage);
            }
        }
    }
}