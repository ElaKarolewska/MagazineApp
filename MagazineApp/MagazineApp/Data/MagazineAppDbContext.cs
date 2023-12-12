
using MagazineApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Data;

public class MagazineAppDbContext: DbContext
{
    public MagazineAppDbContext(DbContextOptions<MagazineAppDbContext> options)
        : base(options) 
    {
    }
    public DbSet<Pharmacie>Pharmacies { get; set; }
    public DbSet<Medicine> Medicines { get; set; }

}

