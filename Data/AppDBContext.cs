using aspCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace aspCMS.Data;

public class AppDBContext : DbContext
{
    private readonly ILogger<AppDBContext> _logger;

    public AppDBContext(ILogger<AppDBContext> logger, DbContextOptions<AppDBContext> options) : base(options)
    {
        _logger = logger;

    }

    public DbSet<Post> Posts { get; set; }
}