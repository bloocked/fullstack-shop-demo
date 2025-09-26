using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    /// <summary>
    /// EF Core <see cref="DbContext"/> for the API: exposes entity sets and configures model rules and seed data
    /// </summary>
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        /// <summary>
        /// Configures the model rules and seeds initial data
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure entities</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(p => p.Stock).IsRequired();

            // Seed users
            var users = new List<User>();
            for (int i = 1; i <= 20; i++)
            {
                var password = $"pass{i}";
                users.Add(new User
                {
                    Id = i,
                    Username = $"user{i}", // gurantees unique but you would have logic checking that
                    Password = $"pass{i}"  // you would hash this
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
