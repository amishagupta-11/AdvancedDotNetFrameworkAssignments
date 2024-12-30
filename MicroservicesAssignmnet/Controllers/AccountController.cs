using MicroservicesAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using UserIdentityApplication.DTOs;

namespace MicroservicesAssignment.Controllers
{
    /// <summary>
    /// Controller responsible for handling user login, registration, and dashboard navigation.
    /// It interacts with an external authentication API for user authentication and role-based redirects.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Initializes the AccountController with an IHttpClientFactory for creating HTTP clients.
        /// </summary>
        /// <param name="httpClientFactory">The IHttpClientFactory to create HTTP clients for API calls.</param>
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Displays the login view.
        /// </summary>
        /// <returns>The login view.</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Handles the login logic by posting the login credentials to the API and processing the response.
        /// On success, stores the JWT token in the session and redirects based on user role.
        /// </summary>
        /// <param name="dto">The login credentials data transfer object.</param>
        /// <returns>Redirects to either the Admin or User Dashboard on success, or displays an error message on failure.</returns>
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

        /// <summary>
        /// Displays the registration view.
        /// </summary>
        /// <returns>The registration view.</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Handles the user registration logic by posting the registration data to the API.
        /// On success, redirects to the login page; otherwise, shows an error message.
        /// </summary>
        /// <param name="dto">The registration data transfer object.</param>
        /// <returns>Redirects to the login page on success, or displays an error message on failure.</returns>
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

        /// <summary>
        /// Displays the Admin Dashboard if the user is authenticated with the Admin role.
        /// Redirects to login if the user is not authenticated or has insufficient role.
        /// </summary>
        /// <returns>The Admin Dashboard view.</returns>
        public IActionResult AdminDashboard()
        {
            if (!IsAuthenticated("Admin"))
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Welcome to the Admin Dashboard!";
            return View();
        }

        /// <summary>
        /// Displays the User Dashboard if the user is authenticated with the User role.
        /// Redirects to login if the user is not authenticated or has insufficient role.
        /// </summary>
        /// <returns>The User Dashboard view.</returns>
        public IActionResult UserDashboard()
        {
            if (!IsAuthenticated("User"))
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Welcome to the User Dashboard!";
            return View();
        }

        /// <summary>
        /// Decodes the JWT token to extract the user role.
        /// </summary>
        /// <param name="token">The JWT token to decode.</param>
        /// <returns>The role associated with the token.</returns>
        private async Task<string> GetUserRole(string token)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role");
            return roleClaim?.Value ?? "User";
        }

        /// <summary>
        /// Checks if the user is authenticated and has the required role.
        /// </summary>
        /// <param name="requiredRole">The required role for authentication.</param>
        /// <returns>True if the user is authenticated and has the required role, otherwise false.</returns>
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
