
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("Validate")]
        public async Task<bool> ValidateProduct ([FromBody] Product product){
            return await Task.Run(() => {
                return (ModelState.IsValid);
            });
            
        }
    }
}