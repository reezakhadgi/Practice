using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Second_Project.Viewmodels;

namespace Second_Project.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(); // This will return the Index.cshtml view in Views/Login/
        }

        //// Handle form submission
        //[HttpPost]
        //public IActionResult Authenticate(string username, string password)
        //{
        //    // Authentication logic here
        //    if (username == "admin" && password == "password")
        //    {
        //        return RedirectToAction("Index", "Home"); // Redirect to Home if login is successful
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "Invalid login credentials.";
        //        return View("Index"); // Stay on the same page with an error message
        //    }
        //}
        // Authenticate action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            // Find the user by username
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("Login"); // Return the login view with an error
            }

            // Attempt to sign in
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Dashboard"); // Redirect to Dashboard view if login successful
            }
            //else if (result.IsLockedOut)
            //{
            //    ViewBag.ErrorMessage = "Your account is locked.";
            //    return View("Index"); // Handle lockout scenario
            //}
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("Index"); // Invalid login attempt
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

