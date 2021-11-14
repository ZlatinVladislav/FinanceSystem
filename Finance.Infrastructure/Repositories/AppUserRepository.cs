using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Context;
using FinanceSystem.Infrastructure.Interfaces;
using FinanceSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceSystem.Infrastructure.Repositories
{
    public class AppUserRepository : AppUser, IAppUserRepository
    {
        private readonly DbSet<AppUser> _dbSet;
        private readonly IUserAccesor _userAccessor;

        public AppUserRepository(FinanceSystemDBContext dbContext, IUserAccesor userAccessor)
        {
            _userAccessor = userAccessor;
            _dbSet = dbContext.Set<AppUser>();
        }

        public async Task<AppUser> GetUser()
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
        }

        public async Task<AppUser> GetUserByUrlUsername(string userName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}