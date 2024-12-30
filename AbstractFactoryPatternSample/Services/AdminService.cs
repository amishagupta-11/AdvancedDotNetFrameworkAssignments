using AbstractFactoryPatternSample.Interfaces;

namespace AbstractFactoryPatternSample.Services
{
    /// <summary>
    /// Service for handling the admin dashboard functionality.
    /// Implements the IUserService interface.
    /// </summary>
    public class AdminService : IUserService
    {
        /// <summary>
        /// Returns the dashboard for an admin user.
        /// </summary>
        /// <returns>A string representing the admin dashboard.</returns>
        public string GetDashboard()
        {
            return "Admin Dashboard";
        }
    }
}
