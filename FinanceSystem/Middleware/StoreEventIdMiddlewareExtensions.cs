using FinanceSystem.Middleware.Implementation;
using Microsoft.AspNetCore.Builder;

namespace FinanceSystem.Middleware
{
    public static class StoreEventIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }

        public static IApplicationBuilder UseLogRequestMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogRequestMiddleware>();
        }
    }
}