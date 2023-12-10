using MagazineApp.Components.CsvReader;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;


namespace MagazineApp;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;
    private readonly ICsvReader _csvReader;
    //private readonly MagazineAppDbContext _magazineAppDbContext;
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider,IUserCommunication userCommunication,
              IEventHandler eventHandler, ICsvReader csvReader)
    {

        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
        _csvReader = csvReader;
       
   
    }
    public void Run()
    {
        // var pharmacies = _csvReader.ProcessPharmacies("Resources\\Files\\Pharmacies.csv");
        _eventHandler.Subscribe();
        _userCommunication.ChooseWhatToDo();
    }
    //private Pharmacie? ReadFirst(string name)
    //{
    //    return _magazineAppDbContext.Pharmacies.FirstOrDefault(x => x.Name == name);
    //}

    //private void ReadGroupedPharmaciesFromDb()
    //{
    //    var groups = _magazineAppDbContext
    //      .Pharmacies
    //      .GroupBy(g => g.Type)
    //      .Select(x => new
    //      {
    //          Type = x.Key,
    //          Pharmacies = x.ToList()
    //      })
    //      .ToList();

    //    foreach (var group in groups)
    //    {
    //        Console.WriteLine(group.Type);
    //        Console.WriteLine("================");
    //        foreach (var pharmacie in group.Pharmacies)
    //        {
    //            Console.WriteLine($"\t {pharmacie.Locality}");
    //        }
    //    }
    //}
    //private void ReadAllFromDb()
    //{
    //    var pharmaciesFromDb = _magazineAppDbContext.Pharmacies.ToList();

    //    foreach (var pharmacieFromDb in pharmaciesFromDb)
    //    {
    //        Console.WriteLine($"\t{pharmacieFromDb.Name}:{pharmacieFromDb.Locality}");
    //    }
    //}

    //private void InsertData()
    //{
    //    var pharmacies = _csvReader.ProcessPharmacies("Resources\\Files\\Pharmacies.csv");

    //    foreach (var pharmacie in pharmacies)
    //    {
    //        _magazineAppDbContext.Pharmacies.Add(new Pharmacie()
    //        {
    //            Name = pharmacie.Name,
    //            Type = pharmacie.Type,
    //            DateOfAuthorisation = pharmacie.DateOfAuthorisation,
    //            Locality = pharmacie.Locality,
    //            Owner = pharmacie.Owner,
    //        });
    //    }

    //    _magazineAppDbContext.SaveChanges();
    //}
}