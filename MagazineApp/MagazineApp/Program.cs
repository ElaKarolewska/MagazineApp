using MagazineApp.Data;
using MagazineApp.Entities;
using MagazineApp.Repositories;
using MagazineApp.Repositories.Extensions;

var medicineRepository = new SqlRepository<Medicine>(new MagazineAppDbContext(), MedicineAdded);
bool prescriptionDrug = true;
medicineRepository.ItemAdded += MedicineRepositoryOnItemAdded;

void MedicineRepositoryOnItemAdded(object? sender, Medicine e)
{
    Console.WriteLine($"Medicine added => {e.Name} from {sender?.GetType().Name}");
}

AddMedicines(medicineRepository, prescriptionDrug);
WriteAllToConsole(medicineRepository);
static void MedicineAdded(Medicine item) 
{
    Console.WriteLine($"{item.Name} added");
}
static void AddMedicines(IRepository<Medicine> medicineRepository, bool prescriptionDrug)
{
    var medicines = new[]
    {
        new Medicine { Name = "Apap" , Dose = "500mg", PrescriptionDrug = false},
        new Medicine { Name = "Bisocard" , Dose = "10mg",  PrescriptionDrug= true},
        new Medicine { Name = "Ibuprom" , Dose = "400mg", PrescriptionDrug = false}
    };

    medicineRepository.AddBatch(medicines);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}