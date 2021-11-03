
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController
    {
        [HttpPost]
        [Route("Validate")]
        public async Task<bool> ValidateProduct ([FromBody] Product product){
            if(!ModelState.IsValid){
                return await Task.Run(() => {
                    return false;
                });
            } else {
                return await Task.Run(() => {
                    return true;
                });
            } 
        }
    }
}