using AbstractFactoryPatternSample.Interfaces;

namespace AbstractFactoryPatternSample.Services
{
    public class AdminService:IUserService
    {
        public string GetDashboard()
        {
            return "Admin Dashboard";
        }
    }
}
