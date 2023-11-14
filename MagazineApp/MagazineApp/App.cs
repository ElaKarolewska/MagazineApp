using MagazineApp.Entities;
using MagazineApp.Entities.DataProviders;
using MagazineApp.Repositories;
using MagazineApp.Services;

namespace MagazineApp;

public class App : IApp
{
    private readonly IRepository<Medicine> _medicineRepository;
    private readonly IMedicineProvider _medicineProvider;
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;   
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider,IUserCommunication userCommunication,IEventHandler eventHandler)
    {
        _medicineRepository = medicineRepository;
        _medicineProvider = medicineProvider;
        _eventHandler = eventHandler;
        _userCommunication = userCommunication;
    }
    public void Run()
    {
        _eventHandler.Subscribe();
        _userCommunication.ChooseWhatToDo();

    }

}