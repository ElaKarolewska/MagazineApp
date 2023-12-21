using MagazineApp.Components.CsvReader;
using MagazineApp.Data;
using MagazineApp.Data.Entities;

namespace MagazineApp.Services;

public class PharmaciesData : IPharmaciesData
{
    private readonly MagazineAppDbContext _magazineAppDbContext;
    private readonly ICsvReader _csvReader;
    public PharmaciesData(MagazineAppDbContext magazineAppDbContext, ICsvReader csvReader)
    {
        _csvReader = csvReader;
        _magazineAppDbContext = magazineAppDbContext;
        _magazineAppDbContext.Database.EnsureCreated();
    }
    public void PharmaciesInfo()
    {
        InsertData();
        ReadGroupedPharmaciesFromDb();
    }
    public void InsertData()
    {
        var pharmacies = _csvReader.ProcessPharmacies("Resources\\Files\\Pharmacies.csv");

        foreach (var pharmacie in pharmacies)
        {
            _magazineAppDbContext.Pharmacies.Add(new Pharmacie()
            {
                Name = pharmacie.Name,
                Type = pharmacie.Type,
                DateOfAuthorisation = pharmacie.DateOfAuthorisation,
                Locality = pharmacie.Locality,
                Owner = pharmacie.Owner,
            });
        }
        _magazineAppDbContext.SaveChanges();
    }
    private void ReadGroupedPharmaciesFromDb()
    {
        var groups = _magazineAppDbContext
          .Pharmacies
          .GroupBy(g => g.Type)
          .Select(x => new
          {
              Type = x.Key,
              Pharmacies = x.ToList()
          })
          .ToList();

        foreach (var group in groups)
        {
            Console.WriteLine(group.Type);
            Console.WriteLine("================");
            foreach (var pharmacie in group.Pharmacies)
            {
                Console.WriteLine($"\t {pharmacie.Locality}");
            }
        }
    }

}
