namespace PbaSubContractor
{
    public class Customer
    {
        public string Surname { get; set; }
        public long CPR { get; set; }
        public string Mail { get; set; }
        public string WebsiteUrl { get; set; }
        public string CountryUnicode { get; set; }
        public long CardNumber { get; set; }

        public static bool IsValidSurname(string surName){
            return true;
        }

        public static bool IsValidCPR(long cpr){
            return true;
        }
    }
    
}