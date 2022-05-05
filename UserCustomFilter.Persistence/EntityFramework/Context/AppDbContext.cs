using Microsoft.EntityFrameworkCore;
using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.EntityMapping;

namespace UserCustomFilter.Persistence.EntityFramework.Context;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomFilterGroup> CustomFilterGroups { get; set; }
    public DbSet<CustomFilter> CustomFilters { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new CustomFilterGroupMapping());
        modelBuilder.ApplyConfiguration(new CustomFilterMapping());
    }
}