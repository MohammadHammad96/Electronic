using Electronic.API.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronic.API.Persistence
{
    public interface IElectronicRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategory(int id);

        void AddCategory(Category category);

        Task<bool> IsCategoryNameUnique(string categoryName);
    }
}