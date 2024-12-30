using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Repositories
{
    /// <summary>
    /// Repository class for managing customer data.
    /// Provides methods to retrieve customer information either by ID or all customers.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        // Static list of customers for demonstration purposes.
        private static readonly List<Customers> Customers = new List<Customers>
        {
            new Customers { Id = 1, Name = "John Doe", Address = "123 Main St" },
            new Customers { Id = 2, Name = "Jane Smith", Address = "456 Oak Ave" }
        };

        /// <summary>
        /// Gets a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>A customer object if found, otherwise null.</returns>
        public Customers GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Gets all customers in the repository.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public IEnumerable<Customers> GetAllCustomers()
        {
            return Customers;
        }
    }
}
