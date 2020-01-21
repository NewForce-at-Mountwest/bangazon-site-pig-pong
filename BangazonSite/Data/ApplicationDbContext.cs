using System;
using System.Collections.Generic;
using System.Text;
using BangazonSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BangazonSite.Models.ViewModels;

namespace BangazonSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public object ProductType { get; internal set; }
        public object Product { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Building new users with Entity
            
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "admin",
                    LastName = "admin",
                    StreetAddress = "123 Infinity Way",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                    Id = "00000000-ffff-ffff-ffff-ffffffffffff"
                };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user); 
            modelBuilder.Entity<ApplicationUser>().HasMany(user => user.Orders).WithOne(Order => Order.User)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasMany(Order => Order.OrderProducts).WithOne(orderProduct => orderProduct.Order).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().Property(D => D.DateCreated).HasDefaultValueSql("GETDATE()");


            // creating new Order
            modelBuilder.Entity<Order>().HasData(
                
                new Order()
                {
                    Id = 1,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    PaymentTypeId = 2
                },
                  new Order()
                  {
                      Id = 2,
                      UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                      PaymentTypeId = 1


                  },
                    new Order()
                    {
                        Id = 3,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        PaymentTypeId = 3


                    });

// creating new OrderProduct
            modelBuilder.Entity<OrderProduct>().HasData(
                
                new OrderProduct()
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1
                },
                  new OrderProduct()
                  {
                      Id = 2,
                      OrderId = 2,
                      ProductId = 2
                  },
                    new OrderProduct()
                    {
                        Id = 3,
                        OrderId = 3,
                        ProductId = 3
                    });
            // creating new PaymentType
            modelBuilder.Entity<PaymentType>().HasData(

                new PaymentType()
                {
                    Id = 1,
                    AcctNumber = 5678980654324321,
                    Name = "Visa",
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Active = true
                },
                new PaymentType()
                {
                    Id = 2,
                    AcctNumber = 0002000300040005,
                    Name = "Mastercard",
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Active = false
                },
                new PaymentType()
                {
                    Id = 3,
                    AcctNumber = 1278980654222221,
                    Name = "Visa",
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Active = true
                });
                


// creating new Products
            modelBuilder.Entity<Product>().HasData(
                
                new Product()
                {
                    Id = 1,
                    Active = true,
                    City = "Huntington",
                  
                    Description = "Vacuum",
                    LocalDelivery = true,
                    Price = 200.00,
                    ProductImage = null,
                    ProductTypeId = 1,
                    Quantity = 5,
                    Title = "Hoover Vacuum Cleaner",
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                },
                 new Product()
                 {
                     Id = 2,
                     Active = true,
                     City = "Chicago",
                     Description = "Fencing",
                     LocalDelivery = false,
                     Price = 104.99,
                     ProductImage = null,
                     ProductTypeId = 2,
                     Quantity = 10,
                     Title = "Chicken Wire Fencing",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 }, new Product()
                 {
                     Id = 3,
                     Active = true,
                     City = "Hurricane",
                   
                     Description = "Solar Panels",
                     LocalDelivery = true,
                     Price = 2000.00,
                     ProductImage = null,
                     ProductTypeId = 3,
                     Quantity = 5,
                     Title = "Solar windows",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 }, new Product()
                 {
                     Id = 4,
                     Active = true,
                     City = "Winfield",
                     Description = "Vacuum",
                     LocalDelivery = true,
                     Price = 199.99,
                     ProductImage = null,
                     ProductTypeId = 1,
                     Quantity = 200,
                     Title = "Robotic Vacuum",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 }, new Product()
                 {
                     Id = 5,
                     Active = true,
                     City = "Dallas",
                   
                     Description = "Wind Turbine, Harness the power of air",
                     LocalDelivery = true,
                     Price = 20000.00,
                     ProductImage = null,
                     ProductTypeId = 3,
                     Quantity = 1000,
                     Title = "Wind Turbine",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 },
                 new Product()
                 {
                     Id = 6,
                     Active = true,
                     City = "San Diego",
                   
                     Description = "White Picket Fence, The American Dream, Pre-painted",
                     LocalDelivery = true,
                     Price = 100.00,
                     ProductImage = null,
                     ProductTypeId = 2,
                     Quantity = 1000,
                     Title = "White Picket Fence",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 },
                 new Product()
                 {
                     Id = 7,
                     Active = true,
                     City = "Wayne",
                   
                     Description = "Privacy Fence",
                     LocalDelivery = true,
                     Price = 75.00,
                     ProductImage = null,
                     ProductTypeId = 2,
                     Quantity = 10,
                     Title = "Privacy Fence",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 },
                 new Product()
                 {
                     Id = 8,
                     Active = true,
                     City = "Richmond",
                   
                     Description = "Vacuum",
                     LocalDelivery = true,
                     Price = 175.00,
                     ProductImage = null,
                     ProductTypeId = 1,
                     Quantity = 14,
                     Title = "Roomba",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 },
                 new Product()
                 {
                     Id = 9,
                     Active = true,
                     City = "Pittsburgh",
                   
                     Description = "Portable Grist Mill, harness the power of your local water source",
                     LocalDelivery = true,
                     Price = 350.00,
                     ProductImage = null,
                     ProductTypeId = 3,
                     Quantity = 2,
                     Title = "Portable Grist Mill",
                     UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                 });

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType()
                {
                    Id = 1,
                    Name = "Cleaning Appliance"
                },
                new ProductType()
                {
                    Id = 2,
                    Name = "Fencing"
                },
                new ProductType()
                {
                    Id = 3,
                    Name = "Energy Tools"
                });


        }

        public DbSet<BangazonSite.Models.ViewModels.ProductTypesViewModel> ProductTypesViewModel { get; set; }
    }
}
