using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportStore.Data;

namespace SportStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170115211257_CreateTableCategory")]
    partial class CreateTableCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SportStore.Models.City", b =>
                {
                    b.Property<string>("Postalcode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Postalcode");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SportStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityPostalcode")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("CustomerId");

                    b.HasIndex("CityPostalcode");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SportStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime?>("DeliveryDate");

                    b.Property<bool>("Giftwrapping");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("ShippingCityPostalcode")
                        .IsRequired();

                    b.Property<string>("ShippingStreet")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingCityPostalcode");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SportStore.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("SportStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("Price")
                        .HasAnnotation("MaxLength", 18);

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SportStore.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductId");

                    b.Property<int?>("ProductId2");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId2");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("SportStore.Models.Customer", b =>
                {
                    b.HasOne("SportStore.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityPostalcode");
                });

            modelBuilder.Entity("SportStore.Models.Order", b =>
                {
                    b.HasOne("SportStore.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportStore.Models.City", "ShippingCity")
                        .WithMany()
                        .HasForeignKey("ShippingCityPostalcode");
                });

            modelBuilder.Entity("SportStore.Models.OrderLine", b =>
                {
                    b.HasOne("SportStore.Models.Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SportStore.Models.ProductCategory", b =>
                {
                    b.HasOne("SportStore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportStore.Models.Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId2");
                });
        }
    }
}
