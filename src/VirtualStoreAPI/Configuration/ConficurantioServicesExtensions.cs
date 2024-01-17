using Microsoft.EntityFrameworkCore;
using VirtualStory.Infra.Data.Context;

namespace VirtualStore.API.Configuration
{
    public static class ConfigurationServicesExtensions
    {
        public static IServiceCollection DbContextConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VirtualStoreDbContext>(options => options.UseSqlServer(connectionString));

            services.AddDistributedMemoryCache();

            return services;
        }
    }
}