using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController
    {
        [HttpPost]
        [Route("product")]
        public async Task<bool> ValidateProduct ([FromBody] Product product){
            throw new NotImplementedException();
        }
    }
}