using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using Abp.Domain.Entities;
using Ardalis.Specification;

namespace PropertiesApi.Infraestructure.Persistence.Configurations
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.HasKey(e => e.IdPropertyImage).HasName("PK__Property__018BACD5822148A5");

            builder.ToTable("PropertyImage");

            builder.Property(e => e.FileUrl).HasMaxLength(255);

            builder.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("FK__PropertyI__IdPro__04E4BC85");
        }
    }
}
