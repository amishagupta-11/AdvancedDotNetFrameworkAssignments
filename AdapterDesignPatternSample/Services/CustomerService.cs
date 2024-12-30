using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Services
{
    /// <summary>
    /// Service class that acts as a mediator between the controller and the adapter.
    /// Provides methods for getting all customers and retrieving customer details by ID.
    /// </summary>
    public class CustomerService
    {
        private readonly ICustomerAdapter CustomerAdapter;

        /// <summary>
        /// Initializes a new instance of the CustomerService class.
        /// </summary>
        /// <param name="customerAdapter">An instance of ICustomerAdapter to retrieve customer data.</param>
        public CustomerService(ICustomerAdapter customerAdapter)
        {
            CustomerAdapter = customerAdapter;
        }

        /// <summary>
        /// Retrieves all customers using the adapter.
        /// </summary>
        /// <returns>A collection of all customers.</returns>
        public IEnumerable<Customers> GetAllCustomers()
        {
            return CustomerAdapter.GetAllCustomers();
        }

        /// <summary>
        /// Retrieves the detailed information of a specific customer by their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A customer object containing the details (Name, Address) for the given ID.</returns>
        public Customers GetCustomerInfo(int customerId)
        {
            return new Customers
            {
                Id = customerId,
                Name = CustomerAdapter.GetCustomerName(customerId),
                Address = CustomerAdapter.GetCustomerAddress(customerId)
            };
        }
    }
}


