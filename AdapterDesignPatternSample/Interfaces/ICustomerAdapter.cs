using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Interfaces
{
    /// <summary>
    /// Defines the contract for a customer adapter. This adapter provides methods 
    /// to retrieve customer information such as name, address, and a list of all customers.
    /// </summary>
    public interface ICustomerAdapter
    {
        /// <summary>
        /// Retrieves the name of a customer by their unique ID.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The customer's name, or "Unknown" if the customer is not found.</returns>
        string GetCustomerName(int customerId);

        /// <summary>
        /// Retrieves the address of a customer by their unique ID.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The customer's address, or "No address found" if the customer is not found.</returns>
        string GetCustomerAddress(int customerId);

        /// <summary>
        /// Retrieves a list of all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public IEnumerable<Customers> GetAllCustomers();
    }
}
