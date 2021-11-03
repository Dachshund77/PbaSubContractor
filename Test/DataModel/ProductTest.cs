using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PbaSubContractor;
using Xunit;
using Xunit.Sdk;

namespace Test
{
    public class ProductTest
    {
        [Theory]
        [MemberData(nameof(data))]
         public void ModelValidationBehavesCorrect(Product product, bool expected, string msg){
             // Arrange        
             // Act
             // Assert
             try
             {
                  Assert.Equal(expected, ValidateModel(product).Count == 0); 
             }
             catch (System.Exception)
             {
                 throw new XunitException(msg);
             }
         }

        public static IEnumerable<object[]> data =>
            new List<object[]>
            {
                new object[] { GetBaseproduct(), true , "Control object"},
                new object[] { GetBaseproduct(name: "12"), false , "name to short"},
                new object[] { GetBaseproduct(name: "123"), true , "name extreme value"},
                new object[] { GetBaseproduct(name: null), false , "name extreme value"},
                new object[] { GetBaseproduct(price: -1), false , "Price may note be negativ"},
                new object[] { GetBaseproduct(price: 0), false , "Price may not be 0"},
                new object[] { GetBaseproduct(numberInStock: -1), false , "number in stock may not be negative"},
                new object[] { GetBaseproduct(numberInStock: 4), true , "number in stock may be integer"},
                new object[] { GetBaseproduct(sizeInKg : -1), false , "size may not be negative"},
        };
    
        public static Product GetBaseproduct(
            string name = "CoolProduct",
            double price = 99.99,
            long numberInStock = 5,
            double sizeInKg = 2
        ){
            return new Product(){
                Name = name,
                Price = price,
                NumberInStock = numberInStock,
                SizeInKg = sizeInKg
            };
        }

        private IList<ValidationResult> ValidateModel(object model){
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }    
    }
}