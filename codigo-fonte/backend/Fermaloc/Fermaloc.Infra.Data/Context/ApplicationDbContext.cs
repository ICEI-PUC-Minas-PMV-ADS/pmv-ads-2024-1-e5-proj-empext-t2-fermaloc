using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fermaloc.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    public DbSet<Administrator> Administrators {get; set;}
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Equipament> Equipaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
