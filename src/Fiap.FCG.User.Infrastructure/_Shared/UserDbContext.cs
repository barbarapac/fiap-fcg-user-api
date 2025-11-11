using Fiap.FCG.User.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Fiap.FCG.User.Infrastructure._Shared;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        base.OnConfiguring(optionsBuilder);
    }

}
