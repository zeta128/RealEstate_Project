using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using Abp.Domain.Entities;
using Ardalis.Specification;

namespace PropertiesApi.Infraestructure.Persistence.Configurations
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.HasKey(e => e.IdPropertyTrace).HasName("PK__Property__373407C9DF938E04");

            builder.ToTable("PropertyTrace");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Tax).HasColumnType("decimal(15, 2)");
            builder.Property(e => e.Value).HasColumnType("decimal(15, 2)");

            builder.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyTraces)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("FK__PropertyT__IdPro__02084FDA");
        }
    }
}
