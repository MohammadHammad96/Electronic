using System.ComponentModel.DataAnnotations;

namespace Electronic.API.Core.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}