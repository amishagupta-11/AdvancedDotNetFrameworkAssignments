using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Interfaces
{
    public interface ICustomerAdapter
    {
        string GetCustomerName(int customerId);
        string GetCustomerAddress(int customerId);
        public IEnumerable<Customers> GetAllCustomers();
    }
}
