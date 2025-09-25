using Microsoft.EntityFrameworkCore;
using System;
using backend.Models;

namespace backend.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
    }
}
