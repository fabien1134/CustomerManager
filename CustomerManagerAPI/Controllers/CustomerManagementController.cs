using Microsoft.AspNetCore.Mvc;

namespace CustomerManagerAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
