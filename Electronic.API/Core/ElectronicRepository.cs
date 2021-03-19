using Electronic.API.Core.Models;
using Electronic.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task<bool> IsCategoryNameUnique(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
                return true;

            return false;
        }
    }
}
