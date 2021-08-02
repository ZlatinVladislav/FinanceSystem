using System;
using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Context;
using FinanceSystem.Infrastructure.Context.SeedData;
using FinanceSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FinanceSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                // .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp} {Message}{NewLine:1}{Exception:1}")
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                Log.Information("Application is starting");
                var context = services.GetRequiredService<FinanceSystemDBContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager);
                Log.Information("Application started successfully");
            }
            catch (Exception e)
            {
                Log.Error(e, "The application failed to start!");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}