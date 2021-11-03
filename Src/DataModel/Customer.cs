using System.ComponentModel.DataAnnotations;

namespace PbaSubContractor
{
    public class Customer
    {
        private const string URL_REGEXP = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
         private const string MAIL_REGEXP = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        [Required]
        [MinLength(5)]
        public string Surname { get; set; }
        
        [Required]
        public long CPR { get; set; }
        
        [Required]
        [RegularExpression(MAIL_REGEXP)]
    
        public string Mail { get; set; }
        
        [Required]
        [RegularExpression(URL_REGEXP)]
        public string WebsiteUrl { get; set; }
        
        [StringLength(2)]
        public string CountryUnicode { get; set; }
        public long CardNumber { get; set; }

        public static bool IsValidSurname(string surName){
            return true;
        }

        public static bool IsValidCPR(long cpr){
            return true;
        }

        public static bool IsValidMail(string mail){
            return true;
        }

        public static bool IsValidWebSiteUrl(string url){
            return true;
        }

        public static bool IsValidCountryUniCode(string url){
            return true;
        }

        public static bool IsValid(Customer customer){
            return (
                IsValidSurname(customer.Surname) &&
                IsValidCPR(customer.CPR) &&
                IsValidMail(customer.Mail) &&
                IsValidWebSiteUrl(customer.WebsiteUrl) &&
                IsValidCountryUniCode(customer.CountryUnicode)
            );
        }

        public bool IsValid(){
            return IsValid(this);
        }
    }
    
}