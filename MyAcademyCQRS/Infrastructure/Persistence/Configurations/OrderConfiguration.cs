using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderNumber)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(x => x.TotalPrice)
                   .HasPrecision(10, 2);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.HasMany(x => x.OrderItems)
        .WithOne(x => x.Order)
        .HasForeignKey(x => x.OrderId);

        }
    }
}
