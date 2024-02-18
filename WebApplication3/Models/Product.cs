using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quant { get; set; }
        public bool EnableSize { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company comp { get; set; }

    }
}
