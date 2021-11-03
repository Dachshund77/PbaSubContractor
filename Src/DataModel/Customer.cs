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
        [ValidCountryCode]
        public string CountryUnicode { get; set; }
        public long CardNumber { get; set; }

    }
    
}