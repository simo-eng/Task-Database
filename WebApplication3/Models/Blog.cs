using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Blog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="Please Enter The Title")]
        [StringLength(20)]
        [DeniedValues("*" , "abc")]
        public string Title {  get; set; }
        [Required (ErrorMessage ="Please Enter The Description")]
        [RegularExpression(@"^[a-zA-z ' '-'\s]{1,40}$", ErrorMessage ="charcters are not allowed")]
        public string Description { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type? type { get; set; }
    }
}
