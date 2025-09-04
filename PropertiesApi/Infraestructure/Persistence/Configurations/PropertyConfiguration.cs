using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using Abp.Domain.Entities;

namespace PropertiesApi.Infraestructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.IdProperty).HasName("PK__Property__842B6AA7D9515525");

            builder.ToTable("Property");

            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.CodeInternal)
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Price).HasColumnType("decimal(15, 2)");

            builder.HasOne(d => d.Owner).WithMany(p => p.Properties)
                .HasForeignKey(d => d.IdOwner)
                .HasConstraintName("FK__Property__IdOwne__7C4F7684");
        }
    }
}
