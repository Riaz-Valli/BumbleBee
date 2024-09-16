using BumbleBee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BumbleBee.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Check which type of user is logging in
            if (model.UserType == "donor")
            {
                // Process Donor login
                     
            }
            else if (model.UserType == "company")
            {
                // Process Company login
                
            }
            else
            {
                // Handle unexpected user type
                ModelState.AddModelError("", "Invalid user type.");
                return View(model); // Return the view with error
            }

            // Redirect to appropriate view based on the login result
            return RedirectToAction("Index", "Home");
        }

    }
}
