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
    public App(IRepository<Medicine> medicineRepository,IUserCommunication userCommunication,
              IEventHandler eventHandler, ICsvReader csvReader, IPharmaciesData pharmaciesData)
    {

        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
        _csvReader = csvReader;
        _pharmaciesData = pharmaciesData;
    }
    public void Run()
    {
        _eventHandler.Subscribe();
        _userCommunication.ChooseWhatToDo();
        _pharmaciesData.PharmaciesInfo();
    }
}



