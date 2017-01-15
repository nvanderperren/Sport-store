using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Models;

namespace SportStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=SportStore;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelbuiler)
        {
            modelbuiler.Entity<Product>(MapProduct);
            modelbuiler.Entity<City>(MapCity);
            modelbuiler.Entity<Customer>(MapCustomer);
        }

        private void MapCustomer(EntityTypeBuilder<Customer> c)
        {
            c.ToTable("Customer");

            c.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(20);

            c.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            c.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            c.Property(t => t.Street)
                .IsRequired()
                .HasMaxLength(100);

            c.HasOne(t => t.City)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


        }

        private void MapCity(EntityTypeBuilder<City> c)
        {
            c.ToTable("City");

            c.HasKey(t => t.Postalcode);

            c.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private static void MapProduct(EntityTypeBuilder<Product> p)
        {
            p.ToTable("Product");

            p.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            p.Property(t => t.Price)
                .IsRequired()
                .HasMaxLength(18);

        }
    }
}
