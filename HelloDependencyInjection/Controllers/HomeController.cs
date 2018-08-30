using System.Web.Mvc;
using HelloDependencyInjection.Models;
using HelloDependencyInjection.Services;

namespace HelloDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IDateTimeService _dateTimeService;

        public HomeController(IEmailService emailService, IDateTimeService dateTimeService)
        {
            _emailService = emailService;
            _dateTimeService = dateTimeService;
        }

        public ActionResult Index()
        {
            var model = _emailService.Create("jeff@jeffsdomain.com", "geoff@geoffsdomain.com", "The Spelling Of Your Name",
                "Your name is spelled wrong...");
            model.DateTime = _dateTimeService.Date;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}