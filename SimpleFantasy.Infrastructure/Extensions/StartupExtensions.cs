using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleFantasy.Models.IUnitOfWork;

namespace SimpleFantasy.Infrastructure.Extensions
{
    public class StartupExtensions
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FantasyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}