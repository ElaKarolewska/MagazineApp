
using MagazineApp.Repositories;

namespace MagazineApp.Entities.DataProviders
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
            return medicines.SingleOrDefault(x => x.Id == id);
        }

        public List<Medicine> WhereQuantityIsGreaterThan(int quantity)
        {
            var medicines = _medicinesRepository.GetAll();
            return medicines.Where(x => x.QuantityInStock > quantity).ToList();
        }

        public List<Medicine> WhereStartsWith(string prefix)
        {
            var medicines = _medicinesRepository.GetAll();
            return medicines.Where(x =>x.Name.StartsWith(prefix)).ToList();
        }
    }
}
