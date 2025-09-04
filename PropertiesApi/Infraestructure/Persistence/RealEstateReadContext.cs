using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Options;
using System.Reflection;

namespace PropertiesApi.Infraestructure
{
    public class RealEstateReadContext : DbContext
    {
        private readonly AppSettings _appSettingsOptions;
    
        public RealEstateReadContext(IOptionsSnapshot<AppSettings> options)
        {
            _appSettingsOptions = options.Value;
        }
        public virtual DbSet<OwnerProperty> OwnerProperties { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<PropertyImage> PropertyImages { get; set; }

        public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }

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

