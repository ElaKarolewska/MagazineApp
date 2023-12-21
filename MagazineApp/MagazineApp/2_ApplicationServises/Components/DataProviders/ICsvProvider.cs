using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.DataProviders;

public interface ICsvProvider
{
    void GenerateDataFromCsvFile();
    List<Pharmacies> GeneratePharmacies();
    void GenerateXml();
}
