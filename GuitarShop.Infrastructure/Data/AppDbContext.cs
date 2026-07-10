using GuitarShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace GuitarShop.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Guitar> Guitars => Set<Guitar>();
}