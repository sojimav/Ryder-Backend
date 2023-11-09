using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;

namespace Ryder.Api.Configurations
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IWebHostEnvironment env,
            IConfiguration config)
        {
            services.AddDbContextPool<ApplicationContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}