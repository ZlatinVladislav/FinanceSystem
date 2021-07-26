using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceSystem.Application.Interfaces.Base;
using FinanceSystem.Infrastructure.Context;
using FinanceSystem.Infrastructure.Interfaces.Base;
using FinanceSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using FinanceSystem.Infrastructure.Repositories.Base;
using FinanceSystem.Application.Actions;
using System.Reflection;

namespace FinanceSystem
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FinanceSystemDBContext>(options => options.UseSqlServer(_config.GetConnectionString("FinanceSystem")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IBaseRepository<Transaction>, BaseRepository<Transaction>>();
            services.AddScoped<IBaseRepository<TransactionType>, BaseRepository<TransactionType>>();

            services.AddScoped<IGenericAction<Transaction>, GenericAction<Transaction>>();
            services.AddScoped<IGenericAction<TransactionType>, GenericAction<TransactionType>>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceSystem", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
