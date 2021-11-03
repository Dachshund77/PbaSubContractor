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
            if(!ModelState.IsValid){
                return await Task.Run(() => {
                    return false;
                 });
            };

            return await Task.Run(() => {
                if(customer.IsValid()){
                    return true;
                } else {
                    return false;
                } 
            });
            

            /*
            //Customer customer;
            try
            {
                //customer = JsonConvert.DeserializeObject<Customer>(o.ToString());
                return await Task.Run(() => {
                if(customer.IsValid()){
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
            */
        }
    }
}