using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Context
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS database=MyAcademyCQRSDb;integrated security=true;trustServerCertificate=true");
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
    }
}
