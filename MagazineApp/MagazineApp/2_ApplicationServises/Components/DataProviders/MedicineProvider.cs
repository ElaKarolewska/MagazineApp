using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;

namespace MagazineApp.Components.DataProviders
{
    public class MedicineProvider : IMedicineProvider
    {
        private readonly IRepository<Medicine> _medicinesRepository;
        public MedicineProvider(IRepository<Medicine> medicinesRepository)
        {
            _medicinesRepository = medicinesRepository;
        }
        public double GetMaximumPriceOfAllMedicines()
        {
            var medicines = _medicinesRepository.GetAll();
           return medicines.Select(x => x.Price).Max();
        }
        public List<Medicine> OrderByName()
        {
            var medicines = _medicinesRepository.GetAll();
            return medicines.OrderBy(x => x.Name).ToList();
        }
        public Medicine SingleOrDefaultById(int id)
        {
            var medicines = _medicinesRepository.GetAll();
            var medicine = medicines.SingleOrDefault(x => x.Id == id);
            if (medicine == null) 
            {
                Console.WriteLine($"Medicine with id {id} is not exist.");
            }
            return medicine;
        }
        public List<Medicine> WhereQuantityIsGreaterThan(int quantity)
        {
            var medicines = _medicinesRepository.GetAll();
            return medicines.Where(x => x.QuantityInStock > quantity).ToList();
        }
        public List<Medicine> WhereStartsWith(string prefix)
        {
            var medicines = _medicinesRepository.GetAll();
            return medicines.Where(x => x.Name.StartsWith(prefix)).ToList();
        }
    }
}
