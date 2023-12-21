using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.DataProviders;
public class PharmaciesProvider : IPharmaciesProvider
{
    public List<Pharmacies> OrderByName(List<Pharmacies> pharmacies)
    {
        return pharmacies.OrderBy(x => x.Name).ToList();
    }
}
