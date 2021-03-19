using Electronic.API.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronic.API.Persistence
{
    public interface IElectronicRepository
    {
        Task<IEnumerable<Category>> GetCategories(string name = null);

        Task<Category> GetCategory(int id);

        void AddCategory(Category category);

        Task<bool> IsCategoryNameUnique(string name);

        Task<IEnumerable<SubCategory>> GetSubCategories(int categoryId, string name = null);

        Task<SubCategory> GetSubCategory(int categoryId, int id);

        void AddSubCategory(Category category, SubCategory subCategory);

        Task<bool> IsSubCategoryNameUnique(int categoryId, string name);
    }
}