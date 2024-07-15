using CustomerManagerAPI.Pocos;
using CustomerManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagerAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerManagementController(ICustomerService customerService) : Controller
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _customerService.GetCustomers());
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to get customers");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(long customerId)
        {
            try
            {
                return Ok(await _customerService.GetCustomer(customerId));
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to get customer");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewCustomer(CustomerPoco newCustomer)
        {
            try
            {
                await _customerService.SaveNewCustomer(newCustomer);
                return Ok(true);
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to save new customer");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCustomerName(CustomerNamePoco updatedCustomerName)
        {
            try
            {
                await _customerService.UpdateCustomerName(updatedCustomerName);
                return Ok(true);
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to update customer name");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerPoco updatedCustomer)
        {
            try
            {
                await _customerService.UpdateCustomer(updatedCustomer);
                return Ok(true);
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to update customer");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(long customerId)
        {
            try
            {
                await _customerService.DeleteCustomer(customerId);
                return Ok(true);
            }
            catch (Exception e)
            {
                //Save error to database 
                return StatusCode(500, "Failed to delete customer");
            }
        }
    }
}
