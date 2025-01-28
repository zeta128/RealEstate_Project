using Carter;
using PropertiesApi.Domain.Options;
using PropertiesApi.Domain.Interfaces;
using PropertiesApi.Infraestructure.Repositories;
using PropertiesApi.Infraestructure;


namespace PropertiesApi
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Program).Assembly;
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionKey));
            services.AddDbContext<RealEstateDBContext>();
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            services.AddCarter();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient();
            services.AddHealthChecks();
            services.AddAuthorization();
            return services;
        }
    }
}
