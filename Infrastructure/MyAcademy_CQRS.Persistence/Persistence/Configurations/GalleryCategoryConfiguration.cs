using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Configurations
{
    public class GalleryCategoryConfiguration : IEntityTypeConfiguration<GalleryCategory>
    {
        public void Configure(EntityTypeBuilder<GalleryCategory> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Images)
                   .WithOne(x => x.GalleryCategory)
                   .HasForeignKey(x => x.GalleryCategoryId);
        }
    }
}
