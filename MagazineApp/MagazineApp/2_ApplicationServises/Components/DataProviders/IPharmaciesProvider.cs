using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.DataProviders;

public interface IPharmaciesProvider
{
    public List<Pharmacies> OrderByName(List<Pharmacies> pharmacies);
}
