using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Options;
using System.Reflection;

namespace PropertiesApi.Infraestructure.Persistence
{
    public class RealEstateWriteContext : DbContext
    {
        private readonly AppSettings _appSettingsOptions;

        public RealEstateWriteContext(IOptionsSnapshot<AppSettings> options)
        {
            _appSettingsOptions = options.Value;
        }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_appSettingsOptions.DefaultConnection);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}

