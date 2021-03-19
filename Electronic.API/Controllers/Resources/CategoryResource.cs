using System.ComponentModel.DataAnnotations;

namespace Electronic.API.Controllers.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
