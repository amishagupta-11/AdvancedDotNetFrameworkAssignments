using AbstractFactoryPatternSample.Interfaces;
using AbstractFactoryPatternSample.Services;

namespace AbstractFactoryPatternSample.Factories
{
    /// <summary>
    /// Factory class for creating user services based on the provided role.
    /// Implements the IUserServiceFactory interface.
    /// </summary>
    public class UserServiceFactory : IUserServiceFactory
    {
        /// <summary>
        /// Creates an instance of a user service based on the specified role.
        /// </summary>
        /// <param name="role">The role for which to create the user service (e.g., "admin", "user").</param>
        /// <returns>An instance of IUserService corresponding to the given role.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid role is provided.</exception>
        public IUserService CreateUserService(string role)
        {
            return role.ToLower() switch
            {
                "admin" => new AdminService(),
                "user" => new UserService(),   
                _ => throw new ArgumentException("Invalid role") 
            };
        }
    }
}
