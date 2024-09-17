using BumbleBee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace BumbleBee.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly FirebaseAuthProvider _authProvider;

        public RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
            _authProvider = new FirebaseAuthProvider(new FirebaseConfig("")); // Replace with your Firebase API Key
        }

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

        // LogOut the current user
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
        }

        // Handle form submission for registration
        [HttpPost]
        public async Task<IActionResult> Register(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        await connection.OpenAsync();

                        string query = "INSERT INTO SignUp (Email, uPassword, Accepted) VALUES (@Email, @Password, @Accepted)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", login.Email);
                            command.Parameters.AddWithValue("@Password", login.Password);
                            command.Parameters.AddWithValue("@Accepted", false);  // Set Accepted to false

                            await command.ExecuteNonQueryAsync();
                        }

                        return RedirectToAction("Login", "Auth");
                    }
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while registering the user.");
                    Console.WriteLine(ex.Message);
                }
            }

            return View(login);
        }

    }
}
