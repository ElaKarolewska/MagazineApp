using MagazineApp.Components.CsvReader;
using MagazineApp.Components.CsvReader.Models;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;
using System.Xml.Linq;

namespace MagazineApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader; 
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider,IUserCommunication userCommunication,
              IEventHandler eventHandler, ICsvReader csvReader)
    {
          _csvReader = csvReader;
        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
    }
    public void Run()
    {
        _eventHandler.Subscribe();
        _userCommunication.ChooseWhatToDo();

        var medicines = _csvReader.ProcessPharmacies("Resources\\Files\\Pharmacies.csv");

        
      
    
    
    }

}