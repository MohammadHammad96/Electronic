using System.ComponentModel.DataAnnotations;

namespace Electronic.API.Controllers.Resources
{
    public class KeyValuePairResource
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
