using AdapterDesignPatternSample.Interfaces;
using AdapterDesignPatternSample.Models;

namespace AdapterDesignPatternSample.Adapters
{
    public class CustomerAdapter :  ICustomerAdapter
    {
        private readonly ICustomerRepository _customerRepository;
            
        public CustomerAdapter(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string GetCustomerName(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer?.Name ?? "Unknown";
        }

        public string GetCustomerAddress(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer?.Address ?? "No address found";
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}
