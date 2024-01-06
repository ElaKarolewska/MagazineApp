using MagazineApp.Components.DataProviders;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;

namespace MagazineApp._3_UI.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Medicine> _medicineRepository;
    private readonly IMedicineProvider? _medicineProvider;
    private readonly IPharmaciesData _pharmaciesData;

    public UserCommunication(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider
           , IPharmaciesData pharmaciesData)
    {
        _medicineRepository = medicineRepository;
        _medicineProvider = medicineProvider;
        _pharmaciesData = pharmaciesData;
    }
    public void ChooseWhatToDo()
    {
        Console.WriteLine("          Welcome! \n" + "This is an app that organizes the pharmacy magazine. \n" + " ");

        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine();
            Console.WriteLine("1 - to add medicine; \n" +
                              "2 - to remove medicine; \n" +
                              "3 - to show all saved medications; \n" +
                              "4 - to order by name; \n" +
                              "5 - to check the quantity; \n" +
                              "6 - to display medications for a specific letter; \n" +
                              "7 - to get maximum price of all; \n" +
                              "8 - to check ID; \n" +
                              "9 - to get Pharmacies info; \n" +
                              "X - to close app.\n");

            var userInput = GetInputFromUser("What do you want to do? Select the option by pressing the appropriate key:").ToUpper();

            switch (userInput)
            {
                case "1":
                    AddMedicine();
                    break;
                case "2":
                    RemoveMedicine();
                    break;
                case "3":
                    WriteAllToConsole();
                    break;
                case "4":
                    OrderByName();
                    break;
                case "5":
                    WhereQuantityIsGreaterThan();
                    break;
                case "6":
                    WhereStartsWith();
                    break;
                case "7":
                    GetMaximumPriceOfAllMedicines();
                    break;
                case "8":
                    SingleOrDefaultById();
                    break;
                case "9":
                    GetPharmaciesData();
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
    private void GetPharmaciesData()
    {
        _pharmaciesData.PharmaciesInfo();
    }
    private void SingleOrDefaultById()
    {
        var input = GetInputFromUser("Please enter ID:");

        if (int.TryParse(input, out int id))
        {
            Console.WriteLine(_medicineProvider.SingleOrDefaultById(id));
        }
        else
        {
            Console.WriteLine("Invalid value.");
        }
    }
    private void GetMaximumPriceOfAllMedicines()
    {
        Console.WriteLine(_medicineProvider.GetMaximumPriceOfAllMedicines());
    }

    private void WhereStartsWith()
    {
        var letter = GetInputFromUser("Please enter letter:")?.ToUpper();

        foreach (var item in _medicineProvider.WhereStartsWith(letter))
        {
            Console.WriteLine(item);
        }
    }
    private void WhereQuantityIsGreaterThan()
    {
        var input = GetInputFromUser("Please enter quantity you want to check:");
        var quantity = int.Parse(input);

        foreach (var item in _medicineProvider.WhereQuantityIsGreaterThan(quantity))
        {
            Console.WriteLine(item);
        }
    }
    private void OrderByName()
    {
        foreach (var item in _medicineProvider.OrderByName())
        {
            Console.WriteLine(item);
        }
    }
    private void AddMedicine()
    {
        var name = GetInputFromUser("Insert medicine name:");
        EmptyInputWarning(ref name, "Name");
        var dose = GetInputFromUser("Insert medicine dose:");
        EmptyInputWarning(ref dose, "Dose");
        var isPrescriptionString = GetInputFromUser("Is it prescription drug? T or F")?.ToUpper();
        EmptyInputWarning(ref isPrescriptionString, "Prescription");
        bool isPrescription = isPrescriptionString == "T";
        var packSize = GetValueFromUser<int>("How many tablets?");
        var price = GetValueFromUser<double>("What price?");
        var quantity = GetValueFromUser<int>("How many packages?");
        var medicine = new Medicine
        {
            Name = name,
            Dose = dose,
            PrescriptionDrug = isPrescription,
            NumberOfTablets = packSize,
            Price = price,
            QuantityInStock = quantity
        };
        _medicineRepository.Add(medicine);
        _medicineRepository.Save();
    }
    private void RemoveMedicine()
    {
        var input = GetInputFromUser("Insert medicine ID to remove:");
        if (int.TryParse(input, out int id))
        {
            _medicineRepository.GetById(id);
        }
        else
        {
            Console.WriteLine("Invalid value.");
        }
        var medicineToRemove = _medicineRepository.GetById(id);
        if (medicineToRemove is not null)
        {
            _medicineRepository.Remove(medicineToRemove);
            _medicineRepository.Save();
        }
    }
    private void WriteAllToConsole()
    {
        var items = _medicineRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
