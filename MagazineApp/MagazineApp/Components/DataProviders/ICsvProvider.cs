using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.DataProviders;

public interface ICsvProvider
{
    void GenerateDataFromCsvFile();
    List<Pharmacies> GeneratePharmaceries();

    void GenerateXml();

}
