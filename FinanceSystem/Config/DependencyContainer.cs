using FinanceSystem.Application.Actions.Base;
using FinanceSystem.Application.Interfaces;
using FinanceSystem.Application.Interfaces.Base;
using FinanceSystem.Application.Services.Security.Base;
using FinanceSystem.Infrastructure.Interfaces;
using FinanceSystem.Infrastructure.Interfaces.Base;
using FinanceSystem.Infrastructure.Models;
using FinanceSystem.Infrastructure.Repositories;
using FinanceSystem.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceSystem.Config
{
    public static class DependencyContainer
    {
        public static void AddIoCService(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IUserAccesor, UserAccessor>();
            services.AddScoped<ITokenService, TokenService>();

            //Action
            services.AddScoped<IGenericAction<Transaction>, GenericAction<Transaction>>();
            services.AddScoped<IGenericAction<TransactionType>, GenericAction<TransactionType>>();

            //Repository
            services.AddScoped<IBaseRepository<Transaction>, BaseRepository<Transaction>>();
            services.AddScoped<IBaseRepository<TransactionType>, BaseRepository<TransactionType>>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
        }
    }
}