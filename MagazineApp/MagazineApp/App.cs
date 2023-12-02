using MagazineApp.Components.CsvReader;
using MagazineApp.Components.CsvReader.Models;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;

namespace MagazineApp;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider,IUserCommunication userCommunication,
              IEventHandler eventHandler)
    {
        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
    }
    public void Run()
    {
        _eventHandler.Subscribe();
        _userCommunication.ChooseWhatToDo();

    }

}