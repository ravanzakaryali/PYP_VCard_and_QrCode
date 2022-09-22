using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DAL.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<City> Cities => Set<City>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<User> Users => Set<User>();
}