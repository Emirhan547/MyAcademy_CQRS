using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(150);
            builder.Property(x => x.Description)
                 .IsRequired()
                 .HasMaxLength(1000);
            builder.Property(x => x.Price)
                   .HasPrecision(10, 2);

            builder.Property(x => x.ImageUrl)
                   .IsRequired();

            builder.Property(x => x.Rating)
                   .HasDefaultValue(0);
        }
    }
}
