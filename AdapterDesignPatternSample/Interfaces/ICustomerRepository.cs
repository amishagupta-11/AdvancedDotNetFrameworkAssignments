using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Interfaces
{
    /// <summary>
    /// Defines the contract for a customer repository. This repository provides methods 
    /// to retrieve customer data from a data source by customer ID or to get all customers.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves a customer by their unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer object with the specified ID, or null if not found.</returns>
        Customers GetCustomerById(int id);

        /// <summary>
        /// Retrieves a collection of all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public IEnumerable<Customers> GetAllCustomers();
    }
}
