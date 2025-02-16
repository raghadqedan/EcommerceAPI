﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Core.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Devices and gadgets",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Books and literature",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Apparel and accessories",
                            Name = "Clothing"
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ahmed Haggag",
                            Password = "password123",
                            Role = "Admin",
                            UserName = "Haggag281"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tarek Sharim",
                            Password = "password456",
                            Role = "User",
                            UserName = "Tarek777"
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "Id", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Id = 1,
                            ProductId = 1,
                            Price = 299.99m,
                            Quantity = 1m
                        },
                        new
                        {
                            OrderId = 1,
                            Id = 2,
                            ProductId = 4,
                            Price = 9.99m,
                            Quantity = 2m
                        },
                        new
                        {
                            OrderId = 2,
                            Id = 3,
                            ProductId = 3,
                            Price = 19.99m,
                            Quantity = 1m
                        },
                        new
                        {
                            OrderId = 3,
                            Id = 4,
                            ProductId = 2,
                            Price = 799.99m,
                            Quantity = 1m
                        },
                        new
                        {
                            OrderId = 3,
                            Id = 5,
                            ProductId = 5,
                            Price = 9.99m,
                            Quantity = 1m
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalUserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocalUserId = 1,
                            OrderDate = new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            LocalUserId = 2,
                            OrderDate = new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Completed"
                        },
                        new
                        {
                            Id = 3,
                            LocalUserId = 1,
                            OrderDate = new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Shipped"
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Image = "smartphone.jpg",
                            Name = "Smartphone",
                            Price = 299.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Image = "laptop.jpg",
                            Name = "Laptop",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Image = "novel.jpg",
                            Name = "Novel",
                            Price = 19.99m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Image = "tshirt.jpg",
                            Name = "T-Shirt",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Image = "jeans.jpg",
                            Name = "Jeans",
                            Price = 49.99m
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.OrderDetails", b =>
                {
                    b.HasOne("Ecommerce.Core.Entities.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Core.Entities.Products", "Product")
                        .WithMany("OrdersDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Orders", b =>
                {
                    b.HasOne("Ecommerce.Core.Entities.LocalUser", "LocalUser")
                        .WithMany("Orders")
                        .HasForeignKey("LocalUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalUser");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Products", b =>
                {
                    b.HasOne("Ecommerce.Core.Entities.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.LocalUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Products", b =>
                {
                    b.Navigation("OrdersDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
