using MagazineApp;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Medicine>, FileRepository<Medicine>>();
services.AddSingleton<IMedicineProvider, MedicineProvider>();

services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, MagazineApp.Services.EventHandler>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();



//using MagazineApp.Data;
//using MagazineApp.Entities;
//using MagazineApp.Repositories;
//using MagazineApp.Repositories.Extensions;

//Console.WriteLine("          Welcome! \n" + "This is an app that organizes the pharmacy magazine. \n" + " ");

////var medicineRepository = new SqlRepository<Medicine>(new MagazineAppDbContext());
//var medicineRepository = new FileRepository<Medicine>();

//bool prescriptionDrug = true;
//medicineRepository.ItemAdded += MedicineRepositoryOnItemAdded;
//medicineRepository.ItemRemoved += MedicineRepositoryItemRemoved;

////AddMedicinesOnInit(medicineRepository, prescriptionDrug);
//WriteAllToConsole(medicineRepository);

//bool CloseApp = false;

//while (!CloseApp)
//{
//    Console.WriteLine("What do you want to do? Select the option by pressing the appropriate key: \n" + " ");
//    Console.WriteLine("1 - to add medicine; \n" +
//                      "2 - to remove medicine; \n" +
//                      "3 - to show all saved medications; \n" +
//                      "X - to close app.");

//    var userInput = Console.ReadLine()?.ToUpper();

//    switch (userInput)
//    {
//        case "1":
//            AddMedicine(medicineRepository);
//            break;
//        case "2":
//            RemoveMedicine(medicineRepository);
//            break;
//        case "3":
//            WriteAllToConsole(medicineRepository);
//            break;
//        case "X":
//            CloseApp = true;
//            break;
//        default:
//            Console.WriteLine("Invalid operation \n");
//            continue;
//    }
//}
//Console.WriteLine("Now you can press any key to leave.");
//Console.ReadKey();

////static void AddMedicinesOnInit (IRepository<Medicine> medicineRepository, bool prescriptionDrug)
////{

////    var medicines = new []
////    {
////         new Medicine { Name = "Apap", Dose = "500mg", PrescriptionDrug = false },
////         new Medicine { Name = "Bisocard", Dose = "10mg", PrescriptionDrug = true },
////         new Medicine { Name = "Ibuprom", Dose = "400mg", PrescriptionDrug = false }
////    };

////    medicineRepository.AddBatch(medicines);
////}
//static void AddMedicine(IRepository<Medicine>medicineRepository)
//{
//    Console.WriteLine("Insert medicine name:");
//    var name = Console.ReadLine();

//    Console.WriteLine("Insert medicine dose:");
//    var dose =  Console.ReadLine();

//    Console.WriteLine("Is it prescription drug? T or F:");
//    var isPrescriptionString = Console.ReadLine().ToUpper();
//    bool isPrescription = isPrescriptionString == "T";

//    var medicine = new Medicine { Name = name, Dose = dose, PrescriptionDrug = isPrescription };

//    medicineRepository.Add(medicine);
//    medicineRepository.Save();
//}
//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}
//static void MedicineRepositoryOnItemAdded(object? sender, Medicine e)
//{
//    Console.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} - {e.Name} {e.Dose} from {sender?.GetType().Name}");

//    var auditFile = File.AppendText(@"auditMedicine.txt");
//    using (auditFile)
//    {
//        auditFile.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} -  {e.Name} {e.Dose}");
//    }
//}
//static void MedicineRepositoryItemRemoved(object? sender, Medicine e)
//{
//    Console.WriteLine($"Date:{DateTime.Now} Medicine removed: {e.Id} - {e.Name} {e.Dose}");
//    var auditFile = File.AppendText(@"auditMedicine.txt");
//    using (auditFile)
//    {
//        auditFile.WriteLine($"Date: {DateTime.Now} Medicine removed: {e.Id} - {e.Name} {e.Dose}");
//    }

//}
//static void RemoveMedicine(IRepository<Medicine> medicineRepository)
//{
//    Console.WriteLine("Insert medicine ID to remove:");
//    var input = Console.ReadLine();
//    var id = int.Parse(input);

//    var medicineToRemove = medicineRepository.GetById(id);

//    if (medicineToRemove is not null)
//    {
//        medicineRepository.Remove(medicineToRemove);
//        medicineRepository.Save();
//    }
//}