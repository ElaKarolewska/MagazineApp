using MagazineApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Data;

public class MagazineAppDbContext: DbContext
{
    public DbSet<Medicine> Medecines => Set<Medicine>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}

