using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Infrastructure.Persistence.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<OurStory> OurStories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<GalleryCategory> GalleryCategories { get; set; }
    public DbSet<GalleryImage> GalleryImages { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
