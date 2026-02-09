using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Icon)
                   .HasMaxLength(100);
        }
    }
}
