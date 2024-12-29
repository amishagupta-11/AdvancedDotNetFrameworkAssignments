using AdapterDesignPatternSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdapterDesignPatternSample.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // Action method to display customer info
        public IActionResult Index(int? id)  // id is nullable
        {
            if (id.HasValue)
            {
                // If ID is provided, return the specific customer
                var customerInfo = _customerService.GetCustomerInfo(id.Value);
                return View(customerInfo);
            }
            else
            {
                // If no ID is provided, return a list of all customers
                var allCustomers = _customerService.GetAllCustomers();
                return View(allCustomers);
            }
        }
    }
}
