using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace PbaSubContractor
{
    public class ValidCountryCode : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            try
            {
                string StringValues = (string)value;
                result = CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                    .Select(culture => new RegionInfo(culture.LCID))
                        .Any(region => region.TwoLetterISORegionName == StringValues);
            }
            catch (System.Exception)
            {  
                return false;
            }
            return result;
        }   
    }
}