using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController: ControllerBase
    {
        [HttpPost]
        [Route("Validate")]
        public async Task<bool> ValidateCustomer ([FromBody] Customer customer){
            return await Task.Run(() => {
                return (ModelState.IsValid);
            });
        }
    }
}