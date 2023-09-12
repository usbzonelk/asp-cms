using aspCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace aspCMS.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Post> Posts {get;set;}
}