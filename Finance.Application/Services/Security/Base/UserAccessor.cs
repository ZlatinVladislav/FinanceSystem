using System.Security.Claims;
using FinanceSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FinanceSystem.Application.Services.Security.Base
{
    public class UserAccessor : IUserAccesor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}