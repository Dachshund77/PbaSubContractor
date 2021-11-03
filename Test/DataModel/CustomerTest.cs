using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PbaSubContractor;
using Xunit;
using Xunit.Sdk;

namespace Test
{
     public class CustomerTest
     {
        [Theory]
        [MemberData(nameof(data))]
         public void ModelValidationBehavesCorrect(Customer customer, bool expected, string msg){
             // Arrange        
             // Act
             // Assert
             try
             {
                  Assert.Equal(expected, ValidateModel(customer).Count == 0); 
             }
             catch (System.Exception)
             {
                 throw new XunitException(msg);
             }
         }

        public static IEnumerable<object[]> data =>
            new List<object[]>
            {
                new object[] { GetBaseCustomer(), true , "Control object"},
                new object[] { GetBaseCustomer(surname: "ab4s" ) , false , "Surname to short"},
                new object[] { GetBaseCustomer(surname: "12345" ) , true , "Surname extreme values"}, 
                new object[] { GetBaseCustomer(surname: null), false , "Surname null"}, 
                new object[] { GetBaseCustomer(cpr: -1) , false , "Cpr negative"}, 
                new object[] { GetBaseCustomer(mail: null), false , "Mail null"}, 
                new object[] { GetBaseCustomer(mail: "MyMail.com"), false ,"No @ in mail"}, 
                new object[] { GetBaseCustomer(mail: "MyM@ ail.com") , false , " invalid space"}, 
                new object[] { GetBaseCustomer(mail: "MyM@ ailcom") , false , "missing ."}, 
                new object[] { GetBaseCustomer(websiteUrl: "ww.google.com"), false ,"no www"},
                new object[] { GetBaseCustomer(websiteUrl: null), true , "website null"}, 
                new object[] { GetBaseCustomer(countryUnicode: "us"), false , "not capitalized, ISO"}, 
                new object[] { GetBaseCustomer(countryUnicode: "xx"), false , "not ISO"},
                new object[] { GetBaseCustomer(cardNumber: -1), false , "cardnumber negative"},
            };
         
         public static Customer GetBaseCustomer(
             string surname = "SvenBuechner",
             long cpr = 412414,
             string mail = "myMail@gosaf.com",
             string websiteUrl = "www.google.com",
             string countryUnicode = "US",
             long cardNumber = 123
             ){
            return new Customer(){
                Surname = surname,
                CPR = cpr,
                Mail = mail,
                WebsiteUrl = websiteUrl,
                CountryUnicode = countryUnicode,
                CardNumber = cardNumber
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