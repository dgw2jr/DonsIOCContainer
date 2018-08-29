using System.Web.Mvc;
using HelloDependencyInjection.Models;
using HelloDependencyInjection.Services;

namespace HelloDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public ActionResult Index()
        {
            var model = new EmailContentViewModel
            {
                Content = _emailService.Create("jeff@jeffsdomain.com", "geoff@geoffsdomain.com", "Spelling", "Your name is spelled wrong...")
            };

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