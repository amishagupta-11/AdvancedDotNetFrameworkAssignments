using AbstractFactoryPatternSample.Interfaces;

namespace AbstractFactoryPatternSample.Services
{
    public class UserService : IUserService
    {
        public string GetDashboard()
        {
            return "User Dashboard";
        }
    }
}
