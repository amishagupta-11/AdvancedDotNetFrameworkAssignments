using AbstractFactoryPatternSample.Factories;
using AbstractFactoryPatternSample.Interfaces;
using AbstractFactoryPatternSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbstractFactoryPatternSample.Controllers
{
    /// <summary>
    /// Controller that handles requests related to the home page and user dashboard.
    /// Demonstrates the use of the Abstract Factory pattern for creating user services based on the role.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;
        private readonly IUserServiceFactory UserServiceFactory;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="logger">An instance of ILogger to log information and errors.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
            UserServiceFactory = new UserServiceFactory(); 
        }

        /// <summary>
        /// Returns the privacy view.
        /// </summary>
        /// <returns>The privacy view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Handles error and displays error information in case of a failure.
        /// </summary>
        /// <returns>The error view with error details.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Displays the dashboard based on the user's role.
        /// </summary>
        /// <param name="role">The role of the user (e.g., Admin, User, etc.).</param>
        /// <returns>A content result containing the welcome message with the appropriate dashboard.</returns>
        public ActionResult Index(string role)
        {
            Logger.LogInformation($"Accessing dashboard for role: {role}");

            try
            {
                // Creates the appropriate user service based on the role using the factory.
                IUserService userService = UserServiceFactory.CreateUserService(role);
                string dashboard = userService.GetDashboard(); 

                return Content($"Welcome to the {dashboard}");
            }
            catch (ArgumentException ex)
            {
                // Logs the error and returns an error message
                Logger.LogError($"Error: {ex.Message}");
                return Content("Invalid role.");
            }
        }
    }
}
