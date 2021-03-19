using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Electronic.API.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new Collection<SubCategory>();
        }
    }
}
