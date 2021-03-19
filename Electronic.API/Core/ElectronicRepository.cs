using Electronic.API.Core.Models;
using Electronic.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic.API.Core
{
    [System.Runtime.InteropServices.Guid("A87364B9-60D3-42AB-825A-036232FCD0E2")]
    public class ElectronicRepository : IElectronicRepository
    {
        private readonly ElectronicDbContext _context;

        public ElectronicRepository(ElectronicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.Categories.ToListAsync();

            return await _context.Categories.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task<bool> IsCategoryNameUnique(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (category == null)
                return true;

            return false;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories(int categoryId, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.SubCategories.Where(s => s.CategoryId == categoryId).ToListAsync();

            return await _context.SubCategories
                .Where(s => s.Name.Contains(name) && s.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<SubCategory> GetSubCategory(int categoryId, int id)
        {
            return await _context.SubCategories
                .SingleOrDefaultAsync(s => s.CategoryId == categoryId && s.Id == id);
        }

        public void AddSubCategory(Category category, SubCategory subCategory)
        {
            category.SubCategories.Add(subCategory);
        }

        public async Task<bool> IsSubCategoryNameUnique(int categoryId, string name)
        {
            var subCategory = await _context.SubCategories
                    .SingleOrDefaultAsync(s => s.CategoryId == categoryId && s.Name == name);

            if (subCategory == null)
                return true;

            return false;
        }
    }
}
