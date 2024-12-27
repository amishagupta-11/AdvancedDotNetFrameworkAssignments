namespace AbstractFactoryPatternSample.Interfaces
{
    public interface IUserServiceFactory
    {
        IUserService CreateUserService(string role);
    }
}
