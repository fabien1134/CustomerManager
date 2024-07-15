using CustomerManagerAPI.Models;
using CustomerManagerAPI.Pocos;
using CustomerManagerAPI.Repoitories;

namespace CustomerManagerAPI.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task DeleteCustomer(long id)
        {
            ThrowExceptionIfCustomerIdInvalid(id);
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<Customer> GetCustomer(long id)
        {
            ThrowExceptionIfCustomerIdInvalid(id);
            var existingCustomer = await _customerRepository.GetCustomer(id) ?? throw new Exception("Customer does not exist");
            return existingCustomer;
        }

        public async Task<List<Customer>> GetCustomers() => await _customerRepository.GetCustomers();

        public async Task SaveNewCustomer(CustomerPoco newCustomer)
        {
            ThrowExceptionIfCustomerPocoInvalid(newCustomer);
            await _customerRepository.SaveNewCustomer(newCustomer);
        }

        public async Task UpdateCustomer(CustomerPoco updatedCustomer)
        {
            ThrowExceptionIfCustomerIdInvalid(updatedCustomer.Id);
            ThrowExceptionIfCustomerPocoInvalid(updatedCustomer);
            await _customerRepository.UpdateCustomer(updatedCustomer);
        }

        public async Task UpdateCustomerName(CustomerNamePoco updatedCustomer)
        {
            ThrowExceptionIfCustomerIdInvalid(updatedCustomer.Id);
            if (!IsCustomerNameValid(updatedCustomer.FirstName, updatedCustomer.SurName)) throw new Exception("Ensure first and last names are valid");
            await _customerRepository.UpdateCustomerName(updatedCustomer);
        }

        //Use IValidation pattern at later time
        private void ThrowExceptionIfCustomerPocoInvalid(CustomerPoco customerPoco)
        {
            if (!IsCustomerAgeValid(customerPoco.Age)) throw new Exception("Ensure age is valid");
            if (!IsCustomerEmailValid(customerPoco.Email)) throw new Exception("Ensure email is valid");
            if (!IsCustomerNameValid(customerPoco.FirstName, customerPoco.SurName)) throw new Exception("Ensure first and last names are valid");
        }

        private bool IsCustomerAgeValid(long age) => age >= 18 && age <= 130;

        private bool IsCustomerEmailValid(string email) => !string.IsNullOrWhiteSpace(email);

        private bool IsCustomerNameValid(string firstName, string lastName) => !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);

        private void ThrowExceptionIfCustomerIdInvalid(long id)
        {
            if (id <= 0) throw new Exception($"Invalid customer Id: {id}");
        }
    }
}
