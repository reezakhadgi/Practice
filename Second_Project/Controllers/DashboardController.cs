using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Second_Project.Models;

namespace Second_Project.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly NarayaniContext _context;
        public DashboardController(NarayaniContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var test = _context.Doctors.ToList();
            return View("~/Views/Dashboard/Index.cshtml",test);
        }

    } 
}


    

