using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PbaSubContractor
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController: ControllerBase
    {
        [HttpPost]
        [Route("Validate")]
        public async Task<bool> ValidateCustomer (Object o){
            Customer customer;
            try
            {
                customer = JsonConvert.DeserializeObject<Customer>(o.ToString());
                return await Task.Run(() => {
                if(
                Customer.IsValidSurname(customer.Surname) &&
                Customer.IsValidCPR(customer.CPR)
                ){
                    return true;
                } else {
                    return false;
                } 
            });
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}