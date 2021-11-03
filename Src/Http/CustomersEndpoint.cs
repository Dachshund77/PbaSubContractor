using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController: ControllerBase
    {
        [HttpGet]
        [Route("Validate")]
        public string ValidateCustomer (){
            return "An API listing authors of docs.asp.net.";
        }
    }
}