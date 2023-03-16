using Microsoft.EntityFrameworkCore;
using TodoPruebaWebApi.Feature.Services;
using TodoPruebaWebApi.Infraestructure;

namespace TodoPruebaWebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<TodoTaskService, TodoTaskService>();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("sqliteConnection");
            services.AddDbContext<TodoTaskDbContext>(options =>
                options.UseSqlite(connectionString, b => b.MigrationsAssembly("TodoPruebaWebApi")));
        }
    }

}