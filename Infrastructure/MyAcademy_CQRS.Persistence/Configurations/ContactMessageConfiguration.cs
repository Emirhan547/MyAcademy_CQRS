using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Persistence.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired();

            builder.Property(x => x.Email)
                   .IsRequired();

            builder.Property(x => x.Message)
                   .IsRequired();
        }
    }
}
