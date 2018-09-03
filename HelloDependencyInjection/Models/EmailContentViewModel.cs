using System.ComponentModel.DataAnnotations;

namespace HelloDependencyInjection.Models
{
    public class EmailContentViewModel
    {
        [DataType(DataType.MultilineText)]
        public string  Content { get; set; }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }

        public string DateTime { get; set; }
    }
}