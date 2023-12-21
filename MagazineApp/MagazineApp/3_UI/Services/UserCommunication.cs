using MagazineApp.Components.DataProviders;
using MagazineApp.Data;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;

namespace MagazineApp._3_UI.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
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

            var userInput = GetInputFromUser("What do you want to do? Select the option by pressing the appropriate key:").ToUpper();          // Console.ReadLine()?.ToUpper();

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
            var input = GetInputFromUser("Please enter ID:");
           
            if ( int.TryParse(input, out int id))
            {
               Console.WriteLine(_medicineProvider.SingleOrDefaultById(id));
            }                                                                                  
            else 
            {
                Console.WriteLine("Invalid value.");
            }                                                                                     
    }
    private void GetMaximumPriceOfAllMedicines(IMedicineProvider? medicineProvider)
    {
        Console.WriteLine(_medicineProvider.GetMaximumPriceOfAllMedicines());
    }

    private void WhereStartsWith(IMedicineProvider? medicineProvider)
    {
        var letter = GetInputFromUser("Please enter letter:")?.ToUpper();
       
        foreach (var item in _medicineProvider.WhereStartsWith(letter))
        {
           Console.WriteLine(item);
        }
    }
    private void WhereQuantityIsGreaterThan(IMedicineProvider? medicineProvider)
    {
        var input = GetInputFromUser("Please enter quantity you want to check:");
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
        var name = GetInputFromUser("Insert medicine name:");
        EmptyInputWarning (ref name, "name");
        var dose = GetInputFromUser("Insert medicine dose:");
        EmptyInputWarning(ref dose,"dose");
        var isPrescriptionString = GetInputFromUser("Is it prescription drug? T or F")?.ToUpper();
        bool isPrescription = isPrescriptionString == "T";

        var input = GetInputFromUser("How many tablets?");
        var packSize = int.Parse (input);

        var input1 = GetInputFromUser("What price?");
        var price = double.Parse (input1);

        var input2 = GetInputFromUser("How many packages?");
        var quantity = int.Parse (input2);
           
        var medicine = new Medicine { Name = name, Dose = dose, PrescriptionDrug = isPrescription, NumberOfTablets = packSize, 
                                     Price = (double)price, QuantityInStock = quantity};

        medicineRepository.Add(medicine);
        medicineRepository.Save();
    }
    private void RemoveMedicine(IRepository<Medicine> medicineRepository)
    {
           var input = GetInputFromUser("Insert medicine ID to remove:");
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
