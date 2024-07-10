using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public  class ApplicationDbContext:DbContext
    {
       public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetails>().HasKey(x => new { x.OrderId, x.Id, x.ProductId });
            modelBuilder.Entity<Categories>().HasData(
   new Categories { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
   new Categories { Id = 2, Name = "Books", Description = "Books and literature" },
   new Categories { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
);

            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser { Id = 1, Name = "Ahmed Haggag", UserName = "Haggag281", Password = "password123", Role = "Admin" },
                new LocalUser { Id = 2, Name = "Tarek Sharim", UserName = "Tarek777", Password = "password456", Role = "User" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Smartphone", Price = 299.99m, Image = "smartphone.jpg", CategoryId = 1 },
                new Products { Id = 2, Name = "Laptop", Price = 799.99m, Image = "laptop.jpg", CategoryId = 1 },
                new Products { Id = 3, Name = "Novel", Price = 19.99m, Image = "novel.jpg", CategoryId = 2 },
                new Products { Id = 4, Name = "T-Shirt", Price = 9.99m, Image = "tshirt.jpg", CategoryId = 3 },
                new Products { Id = 5, Name = "Jeans", Price = 49.99m, Image = "jeans.jpg", CategoryId = 3 }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { Id = 1, OrderStatus = "Pending", OrderDate = new DateTime(2023, 12, 11), LocalUserId = 1 },
                new Orders { Id = 2, OrderStatus = "Completed", OrderDate = new DateTime(2023, 12, 12), LocalUserId = 2 },
                new Orders { Id = 3, OrderStatus = "Shipped", OrderDate = new DateTime(2023, 12, 13), LocalUserId = 1 }
            );

            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails { Id = 1, OrderId = 1, ProductId = 1, Price = 299.99m, Quantity = 1 },
                new OrderDetails { Id = 2, OrderId = 1, ProductId = 4, Price = 9.99m, Quantity = 2 },
                new OrderDetails { Id = 3, OrderId = 2, ProductId = 3, Price = 19.99m, Quantity = 1 },
                new OrderDetails { Id = 4, OrderId = 3, ProductId = 2, Price = 799.99m, Quantity = 1 },
                new OrderDetails { Id = 5, OrderId = 3, ProductId = 5, Price = 9.99m, Quantity = 1 }
            );

        }

        public DbSet<Categories> Categories { get; set; }
        public   DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }










    }
}
