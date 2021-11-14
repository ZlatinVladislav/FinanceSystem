using System.Reflection;
using System.Text;
using FinanceSystem.Application.Services.Security;
using FinanceSystem.Infrastructure.Context;
using FinanceSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FinanceSystem.Config
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration config)
        {
            //Db
            services.AddDbContext<FinanceSystemDBContext>(options =>
                options.UseSqlServer(config.GetConnectionString("FinanceSystem")));
            services.AddMvc(option => option.EnableEndpointRouting = false);

            //Services
            services.AddIoCService();

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FinanceSystem", Version = "v1"});
            });

            // Setting Identity
            services.AddIdentityCore<AppUser>(opt => { opt.Password.RequireNonAlphanumeric = false; })
                .AddEntityFrameworkStores<FinanceSystemDBContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("TransactionByIdRequirement",
                    policy => { policy.Requirements.Add(new TransactionByIdRequirement()); });
            });

            services.AddTransient<IAuthorizationHandler, IsUserRequirementHandler>();

            return services;
        }
    }
}