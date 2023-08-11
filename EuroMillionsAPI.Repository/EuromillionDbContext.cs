using EuroMillionsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuroMillionsAPI.Repository;

public class EuromillionDbContext : DbContext
{
    public EuromillionDbContext(DbContextOptions<EuromillionDbContext> options) : base(options)
    {

    }

    //public DbSet<Draw> Draws { get; set; }
    public DbSet<Draw> Draws { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DrawMap());
    }

}
