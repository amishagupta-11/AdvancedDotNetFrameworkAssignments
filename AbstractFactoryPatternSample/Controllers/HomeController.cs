using AbstractFactoryPatternSample.Factories;
using AbstractFactoryPatternSample.Interfaces;
using AbstractFactoryPatternSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbstractFactoryPatternSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserServiceFactory _userServiceFactory;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userServiceFactory = new UserServiceFactory();
        }      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }       

        public ActionResult Index(string role)
        {
            _logger.LogInformation($"Accessing dashboard for role: {role}");

            try
            {
                IUserService userService = _userServiceFactory.CreateUserService(role);
                string dashboard = userService.GetDashboard();

                return Content($"Welcome to the {dashboard}");
            }
            catch (ArgumentException ex)
            {
               _logger.LogError($"Error: {ex.Message}");
                return Content("Invalid role.");
            }
        }
    }
}
