using MagazineApp.Data.Entities;

namespace MagazineApp.Components.DataProviders
{
    public interface IMedicineProvider
    {
        public double GetMaximumPriceOfAllMedicines();
        List<Medicine> OrderByName();
        List<Medicine> WhereStartsWith(string prefix);
        List<Medicine> WhereQuantityIsGreaterThan(int quantity);
        Medicine SingleOrDefaultById(int id);
    }
}
