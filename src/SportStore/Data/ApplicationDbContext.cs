using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportStore.Models;

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
            modelbuiler.Ignore<Cart>();
            modelbuiler.Ignore<CartLine>();
            modelbuiler.Entity<Order>(MapOrder);
            modelbuiler.Entity<OrderLine>(MapOrderLine);

        }

        private void MapOrderLine(EntityTypeBuilder<OrderLine> o)
        {
            o.ToTable("OrderLine");

            o.HasKey(t => new {t.OrderId, t.ProductId});

            o.Property(t => t.Price)
                .IsRequired();

            o.Property(t => t.Quantity)
                .IsRequired();

            o.HasOne(t => t.Product)
                .WithMany()
                .IsRequired()
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void MapOrder(EntityTypeBuilder<Order> o)
        {
            o.ToTable("Order");
            

            o.Property(t => t.Giftwrapping)
                .IsRequired();

            o.Property(t => t.OrderDate)
                .IsRequired();

            o.Property(t => t.ShippingStreet)
                .IsRequired()
                .HasMaxLength(100);

            o.HasOne(t => t.ShippingCity)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            o.HasMany(t => t.OrderLines)
                .WithOne()
                .IsRequired()
                .HasForeignKey(t => t.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


        }

        private void MapCustomer(EntityTypeBuilder<Customer> c)
        {
            //tablenaam
            c.ToTable("Customer");

            //properties
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


            //associaties
            c.HasOne(t => t.City)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            c.HasMany(t => t.Orders)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


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
