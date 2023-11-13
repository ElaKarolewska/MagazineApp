using MagazineApp.Entities;
using MagazineApp.Entities.DataProviders;
using MagazineApp.Repositories;

namespace MagazineApp;

public class App : IApp
{
    private readonly IRepository<Medicine> _medicineRepository;
    private readonly IMedicineProvider _medicineProvider;
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider)
    {
        _medicineRepository = medicineRepository;
        _medicineProvider = medicineProvider;

    }
    public void Run()
    {
        var medicines = GenerateSampleMedicines();
        foreach (var item in medicines)
        {
            _medicineRepository.Add(item);
        }

        //Console.WriteLine(_medicinesProvider.());

        //foreach (var item in _medicinesProvider.WhereQuantityIsGreaterThan(100))
        //{
        //    Console.WriteLine(item);
        //}

    }


    public static List<Medicine> GenerateSampleMedicines()
    {
        return new List<Medicine>
        {
            new Medicine
            {
                Id = 1,
                Name = "Apap",
                Dose = "500mg",
                NumberOfTablets = 50,
                PrescriptionDrug = false,
                Price = 25.99,
                QuantityInStock = 100,
            },
            new Medicine
            {
                Id = 2,
                Name = "Ibuprom Max",
                Dose ="400mg",
                NumberOfTablets = 24,
                PrescriptionDrug = false,
                Price = 21.80,
                QuantityInStock = 80,
            },
            new Medicine
            {
                Id = 3,
                Name = "Bisocard",
                Dose = "5mg",
                PrescriptionDrug= true,
                NumberOfTablets = 30,
                Price = 15.84,
                QuantityInStock = 120,
            },
            new Medicine
            {   Id = 4,
                Name = "Acard",
                Dose = "75mg",
                PrescriptionDrug= false ,
                NumberOfTablets = 120,
                Price = 19.75,
                QuantityInStock = 150,
            },
            new Medicine
            {
               Id = 5,
               Name = "Siofor XR",
               Dose = "1000mg",
               PrescriptionDrug= true,
               NumberOfTablets = 30,
               Price = 14.27,
               QuantityInStock= 50,
            },
            new Medicine
            {
               Id = 6,
               Name = "Dobenox Forte",
               Dose = "500mg",
               PrescriptionDrug = false,
               NumberOfTablets = 30,
               Price = 27.60,
               QuantityInStock = 30,
            },
            new Medicine
            { Id = 7,
              Name = "Zyrtec",
              Dose = "10mg",
              PrescriptionDrug= true,
              NumberOfTablets = 30 ,
              Price = 16.62,
              QuantityInStock = 15,

            }
        };
    }
}