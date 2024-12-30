using AdapterDesignPatternSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdapterDesignPatternSample.Controllers
{
    /// <summary>
    /// Controller for handling customer-related actions. It interacts with the 
    /// CustomerService to fetch and display customer information.
    /// </summary>
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the CustomersController with the specified
        /// CustomerService to manage customer-related operations.
        /// </summary>
        /// <param name="customerService">The service for handling customer data.</param>
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Action method to display customer information. If a customer ID is provided, 
        /// it shows information for that specific customer. If no ID is provided, 
        /// it shows a list of all customers.
        /// </summary>
        /// <param name="id">The optional customer ID to retrieve a specific customer.</param>
        /// <returns>A view displaying customer information or a list of customers.</returns>
        public IActionResult Index(int? id)  
        {
            if (id.HasValue)
            {
                // If ID is provided, return the specific customer.
                var customerInfo = _customerService.GetCustomerInfo(id.Value);
                return View(customerInfo);
            }
            else
            {
                // If no ID is provided, return a list of all customers.
                var allCustomers = _customerService.GetAllCustomers();
                return View(allCustomers);
            }
        }
    }
}
