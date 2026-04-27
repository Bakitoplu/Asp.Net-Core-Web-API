using Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;


namespace WebAPI.Extentions
{
    public static class ServicesExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)=> services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureRepositoryManager(this IServiceCollection services)=> services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, IServiceManager>();

         
        
    }
}