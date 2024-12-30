namespace AbstractFactoryPatternSample.Interfaces
{
    /// <summary>
    /// Interface for creating user services based on a given role.
    /// </summary>
    public interface IUserServiceFactory
    {
        /// <summary>
        /// Creates a user service based on the provided role.
        /// </summary>
        /// <param name="role">The role of the user for which the service is created.</param>
        /// <returns>An instance of IUserService corresponding to the role.</returns>
        IUserService CreateUserService(string role);
    }
}
