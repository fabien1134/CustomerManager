using CustomerManagerAPI.Models;
using CustomerManagerAPI.Pocos;

namespace CustomerManagerAPI.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(long id);
        Task SaveNewCustomer(CustomerPoco updatedCustomer);
        Task UpdateCustomer(CustomerPoco updatedCustomer);
        Task UpdateCustomerName(CustomerNamePoco updatedCustomer);
        Task DeleteCustomer(long id);
    }
}
