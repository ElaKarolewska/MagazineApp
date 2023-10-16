using MagazineApp.Data;
using MagazineApp.Entities;
using MagazineApp.Repositories;

var medicineRepository = new SqlRepository<Medicine>(new MagazineAppDbContext());
bool prescriptionDrug = true;

AddMedicines(medicineRepository, prescriptionDrug);
WriteAllToConsole(medicineRepository);
static void AddMedicines(IRepository<Medicine> medicineRepository, bool prescriptionDrug)
{
    medicineRepository.Add(new Medicine { Name = "Apap" , PrescriptionDrug = false });
    medicineRepository.Add(new Medicine { Name = "Bisocard" , PrescriptionDrug = true });
    medicineRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}