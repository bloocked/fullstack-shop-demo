using Microsoft.EntityFrameworkCore;
using System;
using YamSoft_backend.Models;

namespace YamSoft_backend.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
    }
}
