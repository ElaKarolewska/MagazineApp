using MagazineApp.Components.DataProviders;
using MagazineApp.Data;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;

namespace MagazineApp.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<Medicine> _medicineRepository;
    private readonly IMedicineProvider? _medicineProvider;
    private readonly MagazineAppDbContext _magazineAppDbContext;
    private readonly IPharmaciesData _pharmaciesData;

    public UserCommunication(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider, MagazineAppDbContext magazineAppDbContext
           ,IPharmaciesData pharmaciesData)
    {
         _medicineRepository = medicineRepository;
         _medicineProvider = medicineProvider;
         _magazineAppDbContext = magazineAppDbContext;
         _pharmaciesData = pharmaciesData;
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
                              "4 - to order by name; \n" +
                              "5 - to check the quantity; \n" +
                              "6 - to display medications for a specific letter; \n" +
                              "7 - to get maximum price of all; \n" +
                              "8 - to check ID; \n" +
                              "9 - to get Pharmacies info; \n" +
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
                case "4":
                    OrderByName(_medicineProvider);
                    break;
                case "5":
                    WhereQuantityIsGreaterThan(_medicineProvider);
                    break;
                case "6":
                    WhereStartsWith(_medicineProvider);
                    break;
                case "7":
                    GetMaximumPriceOfAllMedicines(_medicineProvider);
                    break;
                case "8":
                    SingleOrDefaultById(_medicineProvider);
                    break;
                case "9":
                   GetPharmaciesData(_magazineAppDbContext);
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

    private void GetPharmaciesData(MagazineAppDbContext magazineAppDbContext)
    {
        _pharmaciesData.PharmaciesInfo();
    }
    private void SingleOrDefaultById(IMedicineProvider? medicineProvider)
    {
            Console.WriteLine("Please enter ID:");
            var input = Console.ReadLine();
           
            if ( int.TryParse(input, out int id))
            {
               Console.WriteLine(_medicineProvider.SingleOrDefaultById(id));
            }                                                                                  
            else 
            {
                Console.WriteLine("Invalid value");
            }                                                                                     
    }
    private void GetMaximumPriceOfAllMedicines(IMedicineProvider? medicineProvider)
    {
        Console.WriteLine(_medicineProvider.GetMaximumPriceOfAllMedicines());
    }

    private void WhereStartsWith(IMedicineProvider? medicineProvider)
    {
        Console.WriteLine("Please enter letter:");
        var letter = Console.ReadLine()?.ToUpper();
       
        foreach (var item in _medicineProvider.WhereStartsWith(letter))
        {
           Console.WriteLine(item);
        }
    }
    private void WhereQuantityIsGreaterThan(IMedicineProvider? medicineProvider)
    {
        Console.WriteLine("Please enter quantity you want to check:");
        var input = Console.ReadLine();
        var quantity = int.Parse(input);

        foreach (var item in _medicineProvider.WhereQuantityIsGreaterThan(quantity))
        {
            Console.WriteLine(item);
        }
    }

    private void OrderByName(IMedicineProvider? medicineProvider)
    {
        foreach (var item in _medicineProvider.OrderByName())
        {
            Console.WriteLine(item);
        }
    }
    private void AddMedicine(IRepository<Medicine> medicineRepository)
    {
        Console.WriteLine("Insert medicine name:");
        var name = Console.ReadLine();

        Console.WriteLine("Insert medicine dose:");
        var dose =  Console.ReadLine();

        Console.WriteLine("Is it prescription drug? T or F:");
        var isPrescriptionString = Console.ReadLine()?.ToUpper();
        bool isPrescription = isPrescriptionString == "T";

        Console.WriteLine("How many tablets?");
        var input = Console.ReadLine();
        var packSize = int.Parse (input);

        Console.WriteLine("What price?");
        var input1 = Console.ReadLine();
        var price = double.Parse (input1);

        Console.WriteLine("How many packages?");
        var input2 = Console.ReadLine();
        var quantity = int.Parse (input2);
           
        var medicine = new Medicine { Name = name, Dose = dose, PrescriptionDrug = isPrescription, NumberOfTablets = packSize, 
                                     Price = (double)price, QuantityInStock = quantity};

        medicineRepository.Add(medicine);
        medicineRepository.Save();
    }
    private void RemoveMedicine(IRepository<Medicine> medicineRepository)
    {
           Console.WriteLine("Insert medicine ID to remove:");
           var input = Console.ReadLine();
           var id = int.Parse(input);

           var medicineToRemove = medicineRepository.GetById(id);

           if (medicineToRemove is not null)
           {
               medicineRepository.Remove(medicineToRemove);
               medicineRepository.Save();
           }
    }
    private void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
