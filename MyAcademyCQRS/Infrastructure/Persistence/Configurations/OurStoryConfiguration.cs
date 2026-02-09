using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class OurStoryConfiguration : IEntityTypeConfiguration<OurStory>
    {
        public void Configure(EntityTypeBuilder<OurStory> builder)
        {
            builder.Property(x => x.Title)
                 .IsRequired();

            builder.Property(x => x.Content)
                   .IsRequired();
        }
    }
}
