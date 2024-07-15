using CustomerManagerAPI.Models;
using CustomerManagerAPI.Pocos;

namespace CustomerManagerAPI.Repoitories
{
    public class CustomerRepository : ICustomerRepository
    {
        //Using as a temporary database for now, will use SQL server if there is enough time
        #region Delete when real database used
        private readonly List<Customer> _savedCustomer = [
            new Customer
            {
            Id=1,
            FirstName ="Josh",
            SurName="Smith",
            Age=34,
            Email="josh@hotmail.co.uk",
            Created=DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
            },
            new Customer
            {
            Id=2,
            FirstName ="Mary",
            SurName="Nylah",
            Age=34,
            Email="mary@hotmail.co.uk",
            Created=DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
            }];

        private long _autoIncrementedId = 2;
        #endregion

        //public CustomerRepository()
        //{
        //    _savedCustomer = new()
        //    {
        //    new Customer
        //    {
        //    Id=1,
        //    FirstName ="Josh",
        //    SurName="Smith",
        //    Age=34,
        //    Email="josh@hotmail.co.uk",
        //    Created=DateTime.UtcNow,
        //    LastUpdated = DateTime.UtcNow
        //    },
        //    new Customer
        //    {
        //    Id=2,
        //    FirstName ="Mary",
        //    SurName="Nylah",
        //    Age=34,
        //    Email="mary@hotmail.co.uk",
        //    Created=DateTime.UtcNow,
        //    LastUpdated = DateTime.UtcNow
        //    }
        //    };
        //}

        public async Task DeleteCustomer(long id) => _savedCustomer.Remove(_savedCustomer.First(c => c.Id == id));

        public async Task<Customer> GetCustomer(long id) => _savedCustomer.FirstOrDefault(c => c.Id == id);

        public async Task<List<Customer>> GetCustomers() => _savedCustomer;

        public async Task SaveNewCustomer(CustomerPoco updatedCustomer)
        {
            #region Delete after real database added
            _autoIncrementedId++;
            #endregion

            _savedCustomer.Add(new Customer
            {
                Id = _autoIncrementedId,
                FirstName = updatedCustomer.FirstName,
                SurName = updatedCustomer.SurName,
                Age = updatedCustomer.Age,
                Email = updatedCustomer.Email,
                Created = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            });
        }

        public async Task UpdateCustomer(CustomerPoco updatedCustomer)
        {
            Customer existingCustomer = _savedCustomer.First(c => c.Id == updatedCustomer.Id);
            UpdateExistingCustomerDetails(existingCustomer, updatedCustomer);
        }

        public async Task UpdateCustomerName(CustomerNamePoco updatedCustomer)
        {
            Customer existingCustomer = _savedCustomer.First(c => c.Id == updatedCustomer.Id);
            UpdateExistingCustomerName(existingCustomer, updatedCustomer);
        }

        private void UpdateExistingCustomerDetails(Customer existingCustomer, CustomerPoco updatedCustomer)
        {
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.SurName = updatedCustomer.SurName;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.Age = updatedCustomer.Age;
            existingCustomer.LastUpdated = DateTime.UtcNow;
        }

        private void UpdateExistingCustomerName(Customer existingCustomer, CustomerNamePoco updatedCustomer)
        {
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.SurName = updatedCustomer.SurName;
            existingCustomer.LastUpdated = DateTime.UtcNow;
        }
    }
}
