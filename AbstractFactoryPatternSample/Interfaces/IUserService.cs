namespace AbstractFactoryPatternSample.Interfaces
{
    /// <summary>
    /// Interface representing the user service with a method to get the user dashboard.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the dashboard for the specific user role.
        /// </summary>
        /// <returns>A string representing the dashboard for the user.</returns>
        public string GetDashboard();
    }
}
