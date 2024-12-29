using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private static readonly List<Customers> _customers = new List<Customers>
        {
            new Customers { Id = 1, Name = "John Doe", Address = "123 Main St" },
            new Customers { Id = 2, Name = "Jane Smith", Address = "456 Oak Ave" }
        };

        public Customers GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Customers> GetAllCustomers()
        {
            return _customers;
        }
    }
}
