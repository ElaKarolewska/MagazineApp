using MagazineApp.Entities;
using MagazineApp.Entities.DataProviders;
using MagazineApp.Repositories;

namespace MagazineApp.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<Medicine> _medicineRepository;
    private readonly IMedicineProvider? _medicineProvider;
    
    public UserCommunication(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider)
    {
        _medicineRepository = medicineRepository;
        _medicineProvider = medicineProvider;
    }
     public void ChooseWhatToDo()
     {
        Console.WriteLine("          Welcome! \n" + "This is an app that organizes the pharmacy magazine. \n" + " ");
        
        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine("What do you want to do? Select the option by pressing the appropriate key: \n" + " ");
            Console.WriteLine("1 - to add medicine; \n" +
                              "2 - to remove medicine; \n" +
                              "3 - to show all saved medications; \n" +
                              "X - to close app.");

            var userInput = Console.ReadLine()?.ToUpper();

            switch (userInput)
            {
                case "1":
                    AddMedicine(_medicineRepository);
                    break;
                case "2":
                    RemoveMedicine(_medicineRepository);
                    break;
                case "3":
                    WriteAllToConsole(_medicineRepository);
                    break;
                case "X":
                    CloseApp = true;
                    break;
                default:
                    Console.WriteLine("Invalid operation \n");
                    continue;
            }
        }
        Console.WriteLine("Now you can press any key to leave.");
        Console.ReadKey();
     }

    private void WriteAllToConsole(object medicineRepository)
    {
        throw new NotImplementedException();
    }

    private void RemoveMedicine(object medicineRepository)
    {
        throw new NotImplementedException();
    }

    private void AddMedicine(object medicineRepository)
    {
        throw new NotImplementedException();
    }
}
