using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}