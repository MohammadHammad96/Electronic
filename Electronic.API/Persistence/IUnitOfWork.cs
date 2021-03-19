using System.Threading.Tasks;

namespace Electronic.API.Persistence
{
    public interface IUnitOfWork
    {
        Task ConfirmChanges();
    }
}
