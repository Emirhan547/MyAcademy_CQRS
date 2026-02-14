using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(x => x.BackgroundImageUrl).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OpeningHours).IsRequired().HasMaxLength(100);
            builder.Property(x => x.HolidayHours).IsRequired().HasMaxLength(100);
        }
    }
}