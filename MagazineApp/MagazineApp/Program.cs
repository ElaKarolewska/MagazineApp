using MagazineApp.Data;
using MagazineApp.Entities;
using MagazineApp.Repositories;

var medicineRepository = new SqlRepository<Medicine>(new MagazineAppDbContext());
bool prescriptionDrug = true;
//bool notPrescriptionDrug = true;

AddMedicines(medicineRepository, prescriptionDrug);
WriteAllToConsole(medicineRepository);

static void AddMedicines(IRepository<Medicine> medicineRepository, bool prescriptionDrug)
{    medicineRepository.Add(new Medicine { NameOfTheMedicine = "Apap" }, false);
    medicineRepository.Add(new Medicine { NameOfTheMedicine = "Bisocard" }, true);
    medicineRepository.Save();
}

//if (prescriptionDrug)
//{
//    Console.WriteLine("Rx");
//}
//else
//{
//    Console.WriteLine("OTC");
//}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}