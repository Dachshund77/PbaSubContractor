using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PbaSubContractor;
using Xunit;

namespace Test
{
    public class ProductsControllerTest
    {
         // No body test?
        [Theory]
        [MemberData(nameof(ProductControllerData))]
        public void ValidatReturnCorrectStatus(bool IsValidModelstate, ObjectResult expected)
        {
            // Arrange
            ProductsController customersController = new ProductsController();
            
            // Act
            customersController.ModelState.Clear();
            if(!IsValidModelstate){
                customersController.ModelState.AddModelError("ForcedError", "For xunitTest");
            }
            
            ActionResult<bool> result = customersController.ValidateProduct(ProductTest.GetBaseproduct()).Result;
                
            // Assert
            Assert.IsType(expected.GetType(), result.Result);
        }

        public static IEnumerable<object[]> ProductControllerData =>
            new List<object[]>
            {
                new object[] { true, new OkObjectResult(true) },
                new object[] { false, new OkObjectResult(false) },
            };
    }
}
