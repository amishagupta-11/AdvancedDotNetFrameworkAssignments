using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Adapters
{
    /// <summary>
    /// Adapter class that implements the ICustomerAdapter interface. It adapts the 
    /// ICustomerRepository methods to provide specific functionalities, such as retrieving
    /// customer names and addresses, as well as listing all customers.
    /// </summary>
    public class CustomerAdapter : ICustomerAdapter
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the CustomerAdapter class with the provided 
        /// ICustomerRepository for fetching customer data.
        /// </summary>
        /// <param name="customerRepository">The repository to fetch customer data from.</param>
        public CustomerAdapter(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets the name of the customer based on the provided customer ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to fetch the name for.</param>
        /// <returns>The name of the customer or "Unknown" if the customer is not found.</returns>
        public string GetCustomerName(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer?.Name ?? "Unknown";
        }

        /// <summary>
        /// Gets the address of the customer based on the provided customer ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to fetch the address for.</param>
        /// <returns>The address of the customer or "No address found" if the customer is not found.</returns>
        public string GetCustomerAddress(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer?.Address ?? "No address found";
        }

        /// <summary>
        /// Gets a list of all customers from the repository.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public IEnumerable<Customers> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}
