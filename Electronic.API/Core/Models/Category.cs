using System.ComponentModel.DataAnnotations;

namespace Electronic.API.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
