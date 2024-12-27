using MicroservicesAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using UserIdentityApplication.DTOs;

namespace MicroservicesAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("Api/Auth/Login", dto);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize into a strongly-typed object
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                var token = result?.Token;

                if (!string.IsNullOrEmpty(token))
                {
                    // Store token in session
                    HttpContext.Session.SetString("AuthToken", token);

                    // Decode token to check roles
                    var role = await GetUserRole(token);

                    if (role == "Admin")
                    {
                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard");
                    }
                }
            }
            var errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Error = $"Login failed. Status code: {response.StatusCode}. Error: {errorContent}";
            return View(dto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Please fill in all fields correctly.";
                return View(dto);
            }

            // Call the API to register the user
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("Api/Auth/Register", dto);

            if (response.IsSuccessStatusCode)
            {
                // On successful registration, redirect to the login page
                return RedirectToAction("Login");
            }

            // If registration fails, capture the error message
            var errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Error = $"Registration failed. Status code: {response.StatusCode}. Error: {errorContent}";

            // Return the Register view with the error message
            return View(dto);
        }
        // Admin Dashboard
        public IActionResult AdminDashboard()
        {
            if (!IsAuthenticated("Admin"))
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Welcome to the Admin Dashboard!";
            return View();
        }

        // User Dashboard
        public IActionResult UserDashboard()
        {
            if (!IsAuthenticated("User"))
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Welcome to the User Dashboard!";
            return View();
        }

        // Helper method to decode JWT and get user role
        private async Task<string> GetUserRole(string token)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role");
            return roleClaim?.Value ?? "User"; 
        }

        private bool IsAuthenticated(string requiredRole)
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
                return false;

            var role = GetUserRole(token).Result;
            return role == requiredRole;
        }
    }
}
