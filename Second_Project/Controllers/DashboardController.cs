using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Second_Project.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
    
}
