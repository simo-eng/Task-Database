using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type type { get; set; }
    }
}
