using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserCustomFilter.Persistence.EntityFramework.Context;

public class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<AppDbContext> options = new();
        options.UseNpgsql("Server=localhost;Port=7000;Database=UserCustomFilterDb;User ID=postgres;Password=123456;Integrated Security=true;Pooling=true;");
        return new AppDbContext(options.Options);
    }
}