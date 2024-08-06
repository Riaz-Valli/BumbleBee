using Microsoft.AspNetCore.Mvc;

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
    }
}
