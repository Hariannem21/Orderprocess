using Microsoft.EntityFrameworkCore;
using OrderProcess.API.Entities;

namespace OrderProcess.API.Contexts
{
    public class ProcessOrderContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ProcessOrderContext(DbContextOptions<ProcessOrderContext> options)
           : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasData(
                new User()
                {
                    Id = 1,
                    Name = "Sam",
                },
                new User()
                {
                    Id = 2,
                    Name = "Bob",
                },
                new User()
                {
                    Id = 3,
                    Name = "Ben",
                });

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product()
                    {
                        Id = 1,
                        AvaliableQuantity = 10,
                        Price = 100
                    },
                    new Product()
                    {
                        Id = 2,
                        AvaliableQuantity = 3,
                        Price = 1000
                    },
                    new Product()
                    {
                        Id = 3,
                        AvaliableQuantity = 0,
                        Price = 10
                    });

            modelBuilder.Entity<Order>()
                          .HasData(
                            new Order()
                            {
                                Id = 1,
                                UserId = 1,
                                ProductId = 1,
                                Quantity = 10
                            },
                            new Order()
                            {
                                Id = 2,
                                UserId = 1,
                                ProductId = 1,
                                Quantity = 10
                            },
                              new Order()
                              {
                                  Id = 3,
                                  UserId = 2,
                                  ProductId = 2,
                                  Quantity = 10
                              },
                            new Order()
                            {
                                Id = 4,
                                UserId = 2,
                                ProductId = 3,
                                Quantity = 10
                            },
                            new Order()
                            {
                                Id = 5,
                                UserId = 3,
                                ProductId = 2,
                                Quantity = 10
                            },
                            new Order()
                            {
                                Id = 6,
                                UserId = 3,
                                ProductId = 3,
                                Quantity = 10
                            }
                            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
