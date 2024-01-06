using MagazineApp._3_UI.Services;
using MagazineApp.Services;

namespace MagazineApp;
public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandler _eventHandler;
    public App(IUserCommunication userCommunication, IEventHandler eventHandler)
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



