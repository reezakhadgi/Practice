using Microsoft.AspNetCore.Mvc;

namespace Second_Project.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will return the Index.cshtml view in Views/Login/
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            // Authentication logic here
            if (username == "admin" && password == "password")
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home if login is successful
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid login credentials.";
                return View("Index"); // Stay on the same page with an error message
            }
        }
    }
}
