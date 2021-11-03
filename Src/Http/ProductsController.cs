
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
        public async Task<ActionResult<bool>> ValidateProduct ([FromBody] Product product){
            return await Task.Run(() => {
                return Ok(ModelState.IsValid);
            });
            
        }
    }
}