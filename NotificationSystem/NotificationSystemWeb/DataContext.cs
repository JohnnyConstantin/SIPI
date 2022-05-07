using Microsoft.EntityFrameworkCore;
using NotificationSystemWeb.Models;

namespace NotificationSystemWeb.Data;

public class DataContext : DbContext
{
    /// <summary>
    /// Basic Class for DB connection. Connection string is in appsettings.json.
    /// </summary>
    private readonly IConfiguration _config;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Stack> Stacks { get; set; } = null!;
    public DbSet<Vulnerability> Vulnerabilities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
    }
}