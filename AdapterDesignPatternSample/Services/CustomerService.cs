using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Services
{
    public class CustomerService
    {
        private readonly ICustomerAdapter _customerAdapter;

        public CustomerService(ICustomerAdapter customerAdapter)
        {
            _customerAdapter = customerAdapter;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            // Assuming you have a method to get all customers in your repository
            return _customerAdapter.GetAllCustomers();  
        }

        public Customers GetCustomerInfo(int customerId)
        {
            return new Customers
            {
                Id = customerId,
                Name = _customerAdapter.GetCustomerName(customerId),
                Address = _customerAdapter.GetCustomerAddress(customerId)
            };
        }
    }
}
