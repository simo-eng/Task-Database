using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;

namespace WebApplication3.Util
{
    public class MaxPriceAttribute : ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceAttribute(int maxPrice)
        {
            _maxPrice = maxPrice;
        }


        protected override ValidationResult? IsValid(Object value, ValidationContext validationContext)
        {
            Product p = (Product)validationContext.ObjectInstance;
            int price;
            if (!int.TryParse(value.ToString(), out price))
            {
                return new ValidationResult("enter int value");
            }
            if (p.CompanyId == 1 && price > _maxPrice)
            {
                return new ValidationResult("Nike price less than " + _maxPrice.ToString());
            }
            return ValidationResult.Success;
        }

      
        }
}
