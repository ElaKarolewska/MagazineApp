
using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);
    List<Manufacturer> ProcessManufacturers(string filePath);
    List<Medicines> ProcessMedicines(string filePath);
    List<Pharmacies> ProcessPharmacies(string filePath);
}
