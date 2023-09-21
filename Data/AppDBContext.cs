using aspCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using aspCMS.Auth;

namespace aspCMS.Data
{
    public class AppDBContext : DbContext
    {
        private readonly ILogger<AppDBContext> _logger;

        public AppDBContext(ILogger<AppDBContext> logger, DbContextOptions<AppDBContext> options) : base(options)
        {
            _logger = logger;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AdminUsers>().ToTable("Administrators");
        }

        public DbSet<Post> Posts { get; set; }
    }
}