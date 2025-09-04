using Carter;
using PropertiesApi.Domain.Options;
using PropertiesApi.Domain.Interfaces;
using PropertiesApi.Infraestructure.Repositories;
using PropertiesApi.Infraestructure.Persistence;
using Microsoft.Extensions.Options;
using PropertiesApi.Infraestructure;
using PropertiesApi.Infraestructure.Repositories.Contracts;


namespace PropertiesApi
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Program).Assembly;
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionKey));
            #region WriteContext

            services.AddDbContext<RealEstateWriteContext>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
                DbContextOptionSetup.ConfigureWriteOptions(options, appSettings.DefaultConnection);
            });

            #endregion

            #region ReadContext

            services.AddDbContext<RealEstateReadContext>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
                DbContextOptionSetup.ConfigureReadOptions(options, appSettings.DefaultConnection);
            });

            #endregion
            #region Repositories
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
            #endregion
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            services.AddCarter();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient();
            services.AddHealthChecks();
            services.AddAuthorization();
            return services;
        }
    }
}
