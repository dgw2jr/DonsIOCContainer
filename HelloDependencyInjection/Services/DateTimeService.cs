using System;

namespace HelloDependencyInjection.Services
{
    public class DateTimeService : IDateTimeService
    {
        public string Date => DateTime.Now.ToShortDateString();
    }
}