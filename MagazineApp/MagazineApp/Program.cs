using MagazineApp.Data;
using MagazineApp.Entities;
using MagazineApp.Repositories;
using MagazineApp.Repositories.Extensions;
using System.Text.Json;
using Newtonsoft.Json;

Console.WriteLine("          Welcome! \n" + "This is an app that organizes the pharmacy magazine. \n" + " ");

var medicineRepository = new SqlRepository<Medicine>(new MagazineAppDbContext(), MedicineAdded, MedicineRemoved);
bool prescriptionDrug = true;
medicineRepository.ItemAdded += MedicineRepositoryOnItemAdded;
medicineRepository.ItemRemoved += MedicineRepositoryItemRemoved;

static void MedicineRepositoryOnItemAdded(object? sender, Medicine e)
{
    Console.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} - {e.Name} {e.Dose} from {sender?.GetType().Name}");

    var auditFile = File.AppendText(@"auditMedicine.txt");
    using (auditFile)
    {
        auditFile.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} -  {e.Name} {e.Dose}");
    }
}
static void MedicineRepositoryItemRemoved(object? sender, Medicine e)
{
    Console.WriteLine($"Date:{DateTime.Now} Medicine removed: {e.Id} - {e.Name} {e.Dose}");
    var auditFile = File.AppendText(@"auditMedicine.txt");
    using (auditFile)
    {
        auditFile.WriteLine($"Date: {DateTime.Now} Medicine removed: {e.Id}");
    }

}
static void MedicineAdded(Medicine item)
{
    Console.WriteLine($"Medicine added: {item}");
}

static void MedicineRemoved(Medicine item)
{
    Console.WriteLine($"Medicine removed: {item}");
}

AddMedicines(medicineRepository, prescriptionDrug);
WriteAllToConsole(medicineRepository);
static void RemoveMedicine(IRepository<Medicine> medicineRepository, bool prescriptionDrug)
{
    string medicinesSerialized = JsonConvert.SerializeObject(medicineRepository);
}

bool CloseApp = false;

while (!CloseApp)
{
    Console.WriteLine("What do you want to do? Select the option by pressing the appropriate key: \n" + " ");
    Console.WriteLine("1 - to add medicine to the file; \n" +
                      "2 - to remove medicine from the file; \n" +
                      "3 - to show all saved medications; \n" +
                      "X - to close app.");

    var userInput = Console.ReadLine()?.ToUpper();

    switch (userInput)
    {
        case "1":
            AddMedicines(medicineRepository, prescriptionDrug);
            break;
        case "2":
            RemoveMedicine(medicineRepository, prescriptionDrug);
            break;
        case "3":
            WriteAllToConsole(medicineRepository);
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

static void AddMedicines (SqlRepository<Medicine> medicineRepository, bool prescriptionDrug)
{
//    //Console.WriteLine("Please insert name, dose and true or false if it's a prescription drug:");
//    // Console.ReadLine();

    var medicines = new []
    {
         new Medicine { Name = "Apap", Dose = "500mg", PrescriptionDrug = false },
         new Medicine { Name = "Bisocard", Dose = "10mg", PrescriptionDrug = true },
         new Medicine { Name = "Ibuprom", Dose = "400mg", PrescriptionDrug = false }
    };

    string medicinesSerialized = JsonConvert.SerializeObject(medicines);
    File.WriteAllText(@"D:\Projekty\Json\save.json", medicinesSerialized);

    //medicineRepository.AddBatch(medicines);

}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}


