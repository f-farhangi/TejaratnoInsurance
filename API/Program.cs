using API.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Write By My Husband
            var host = CreateHostBuilder(args).Build();

            using var scop = host.Services.CreateScope();
            var services = scop.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = services.GetRequiredService<AppDbContext>();
                await dbContext.Database.MigrateAsync();
                
            }
            catch (Exception ex)
            {
                var _logger = loggerFactory.CreateLogger<Program>();
                _logger.LogError(ex, "An error occured during migration");
            }

            host.Run();
            //
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
