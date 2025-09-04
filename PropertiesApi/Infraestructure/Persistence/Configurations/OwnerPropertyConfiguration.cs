using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using System.Reflection.Emit;

namespace PropertiesApi.Infraestructure.Persistence.Configurations
{
    public class OwnerPropertyConfiguration : IEntityTypeConfiguration<OwnerProperty>
    {
        public void Configure(EntityTypeBuilder<OwnerProperty> builder)
        {
            builder.HasKey(e => e.IdOwner).HasName("PK__OwnerPro__D3261816C7369885");

            builder.ToTable("OwnerProperty");

            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
