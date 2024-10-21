using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Second_Project.Viewmodels;

namespace Second_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

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
        
        public IActionResult Register() => View();

 

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // You can sign the user in here or redirect them
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

    }
}

