using Microsoft.Extensions.DependencyInjection;
using SimpleFantasy.Identity.IServices;
using SimpleFantasy.Identity.Services;

namespace SimpleFantasy.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
