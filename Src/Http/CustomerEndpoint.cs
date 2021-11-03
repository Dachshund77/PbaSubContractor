using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    public class CustomerEndpoint
    {
        [HttpPost]
        [Route("product")]
        public async Task<bool> ValidateCustomer ([FromBody] Customer customer){
            throw new NotImplementedException();
        }
    }
}