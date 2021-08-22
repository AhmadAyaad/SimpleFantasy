using Microsoft.Extensions.DependencyInjection;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Core.Services;

namespace SimpleFantasy.Core.Extensions
{
    public static class CoreExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<INationalityService, NationalityService>();
        }
    }
}
