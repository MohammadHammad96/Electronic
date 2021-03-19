using Electronic.API.Persistence;
using System.Threading.Tasks;

namespace Electronic.API.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectronicDbContext _context;

        public UnitOfWork(ElectronicDbContext context)
        {
            _context = context;
        }

        public async Task ConfirmChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}