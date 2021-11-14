using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Infrastructure.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUser();
        Task<AppUser> GetUserByUrlUsername(string userName);
    }
}