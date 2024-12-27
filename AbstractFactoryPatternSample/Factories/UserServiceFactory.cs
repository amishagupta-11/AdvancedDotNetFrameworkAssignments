using AbstractFactoryPatternSample.Interfaces;
using AbstractFactoryPatternSample.Services;

namespace AbstractFactoryPatternSample.Factories
{
    public class UserServiceFactory:IUserServiceFactory
    {
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
