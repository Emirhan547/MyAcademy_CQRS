using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.DiscountPrice)
                   .HasPrecision(10, 2);

            builder.Property(x => x.ExpireDate)
                   .IsRequired();
        }
    }
}
