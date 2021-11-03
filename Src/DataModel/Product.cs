using System;
using System.ComponentModel.DataAnnotations;
namespace PbaSubContractor

{
    public class Product
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        
        [Range(double.Epsilon,Double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public long NumberInStock { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double SizeInKg { get; set; }
    }
}