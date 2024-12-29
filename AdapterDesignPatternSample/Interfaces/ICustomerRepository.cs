using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Interfaces
{
    public interface ICustomerRepository
    {
        Customers GetCustomerById(int id);
        public IEnumerable<Customers> GetAllCustomers();
    }
}
