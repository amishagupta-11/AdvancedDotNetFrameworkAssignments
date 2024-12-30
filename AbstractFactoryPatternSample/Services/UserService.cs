using AbstractFactoryPatternSample.Interfaces;

namespace AbstractFactoryPatternSample.Services
{
    /// <summary>
    /// Service for handling the user dashboard functionality.
    /// Implements the IUserService interface.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Returns the dashboard for a regular user.
        /// </summary>
        /// <returns>A string representing the user dashboard.</returns>
        public string GetDashboard()
        {
            return "User Dashboard";
        }
    }
}
