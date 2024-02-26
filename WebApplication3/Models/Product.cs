using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Util;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "you must enter the name of the product")]
        [DeniedValues("aaa","bbb")]
        [Length(1, 6)]



        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(100, 6000)]
        [MaxPrice(300)]
        public float Price { get; set; }
        [Required]
        public int Quant { get; set; }
        
        public bool EnableSize { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? comp { get; set; }

    }
}
