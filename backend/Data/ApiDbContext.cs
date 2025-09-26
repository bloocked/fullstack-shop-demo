using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                

            // Seed users
            var users = new List<User>();
            for (int i = 1; i <= 20; i++)
            {
                var password = $"pass{i}";
                users.Add(new User
                {
                    Id = i,
                    Username = $"user{i}",
                    Password = $"pass{i}" // you would hash this
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            // Seed products
            var products = new List<Product>();

            for (int i = 1; i <= 50; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Description = $"Description for product {i}",
                    Price = Math.Round((decimal)(10 * i), 2),
                    Stock = 2*i
                });
            }
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
