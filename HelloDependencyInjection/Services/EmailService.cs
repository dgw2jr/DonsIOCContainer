using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloDependencyInjection.Services
{
    public class EmailService : IEmailService
    {
        public string Create(string toAddress, string fromAddress, string subject, string body)
        {
            return $"Dear {toAddress}, {body}{Environment.NewLine} Sincerely, {fromAddress}";
        }
    }
}