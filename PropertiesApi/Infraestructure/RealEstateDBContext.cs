using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Options;
using System.Reflection;

namespace PropertiesApi.Infraestructure
{
    public class RealEstateDBContext : DbContext
    {
        private readonly AppSettings _appSettingsOptions;
        //public RealEstateDBContext(IOptionsSnapshot<AppSettings> appSettingsOptions) : base((DbContextOptions)appSettingsOptions)
        //{
        //    _appSettingsOptions = appSettingsOptions.Value;
        //}

        //public RealEstateDBContext(DbContextOptions<RealEstateDbContext> options)
        //    : base(options)
        //{

        ////}
        public RealEstateDBContext(IOptionsSnapshot<AppSettings> options)
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
            modelBuilder.Entity<OwnerProperty>(entity =>
            {
                entity.HasKey(e => e.IdOwner).HasName("PK__OwnerPro__D3261816C9F839F9");

                entity.ToTable("OwnerProperty");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty).HasName("PK__Property__842B6AA726B4BEE3");

                entity.ToTable("Property");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CodeInternal)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Properties)
                    .HasForeignKey(d => d.IdOwner)
                    .HasConstraintName("FK__Property__IdOwne__59063A47");
            });

            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.IdPropertyImage).HasName("PK__Property__018BACD592431DE6");

                entity.ToTable("PropertyImage");

                entity.Property(e => e.FileUrl).HasMaxLength(255);
            });

            modelBuilder.Entity<PropertyTrace>(entity =>
            {
                entity.HasKey(e => e.IdPropertyTrace).HasName("PK__Property__373407C9CCE58C77");

                entity.ToTable("PropertyTrace");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Tax).HasColumnType("decimal(15, 2)");
                entity.Property(e => e.Value).HasColumnType("decimal(15, 2)");
            });

           
        }

        
    }
}

