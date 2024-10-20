using Microsoft.AspNetCore.Mvc;
using Second_Project.Models;
using System.Diagnostics;

namespace Second_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NarayaniContext _context; //Dependency injection used

        public HomeController(ILogger<HomeController> logger, NarayaniContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            var test=_context.Doctors.OrderByDescending(x=>x.Id).First();
            return View(test);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
