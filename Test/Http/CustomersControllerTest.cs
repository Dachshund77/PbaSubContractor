using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PbaSubContractor;
using Xunit;

namespace Test
{
    public class CustomersControllerTest
    {
        [Theory]
        [MemberData(nameof(CustomerControllerData))]
        public void ValidatReturnCorrectStatus(bool IsValidModelstate, ObjectResult expected)
        {
            // Arrange
            CustomersController customersController = new CustomersController();
            
            // Act
            customersController.ModelState.Clear();
            if(!IsValidModelstate){
                customersController.ModelState.AddModelError("ForcedError", "For xunitTest");
            }
            
            ActionResult<bool> result = customersController.ValidateCustomer(CustomerTest.GetBaseCustomer()).Result;
                
            // Assert
            Assert.IsType(expected.GetType(), result.Result);
        }

        public static IEnumerable<object[]> CustomerControllerData =>
            new List<object[]>
            {
                new object[] { true, new OkObjectResult(true) },
                new object[] { false, new OkObjectResult(false) },
            };
    }
}
