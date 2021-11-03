using System.ComponentModel.DataAnnotations;
namespace PbaSubContractor

{
    public class Product
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long NumberInStock { get; set; }
        [Required]
        public double SizeInKg { get; set; }
    }
}