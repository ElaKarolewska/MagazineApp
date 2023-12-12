using MagazineApp.Components.CsvReader;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;


namespace MagazineApp;

public class App : IApp
{
    private readonly IPharmaciesData _pharmaciesData;
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;
    private readonly ICsvReader _csvReader;
    private readonly MagazineAppDbContext _magazineAppDbContext;
    public App(IRepository<Medicine> medicineRepository,IMedicineProvider medicineProvider,IUserCommunication userCommunication,
              IEventHandler eventHandler, ICsvReader csvReader, MagazineAppDbContext magazineAppDbContext, IPharmaciesData pharmaciesData)
    {

        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
        _csvReader = csvReader;
        _magazineAppDbContext = magazineAppDbContext;
        _magazineAppDbContext.Database.EnsureCreated();
        _pharmaciesData = pharmaciesData;
    }
    public void Run()
    {
       _eventHandler.Subscribe();
       _userCommunication.ChooseWhatToDo();
       //_pharmaciesData.PharmaciesInfo();
    }

}