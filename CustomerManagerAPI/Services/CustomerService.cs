using CustomerManagerAPI.Models;
using CustomerManagerAPI.Pocos;
using CustomerManagerAPI.Repoitories;

namespace CustomerManagerAPI.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task DeleteCustomer(long id) => await _customerRepository.DeleteCustomer(id);

        public async Task<Customer> GetCustomer(long id) => await _customerRepository.GetCustomer(id);

        public async Task<List<Customer>> GetCustomers() => await _customerRepository.GetCustomers();

        public async Task SaveNewCustomer(CustomerPoco updatedCustomer) => await _customerRepository.SaveNewCustomer(updatedCustomer);

        public async Task UpdateCustomer(CustomerPoco updatedCustomer) => await _customerRepository.UpdateCustomer(updatedCustomer);

        public async Task UpdateCustomerName(CustomerNamePoco updatedCustomer) => await _customerRepository.UpdateCustomerName(updatedCustomer);
    }
}
