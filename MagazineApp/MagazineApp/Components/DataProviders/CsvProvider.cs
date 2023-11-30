using MagazineApp.Components.CsvReader;
using MagazineApp.Components.CsvReader.Models;

namespace MagazineApp.Components.DataProviders;

public class CsvProvider : ICsvProvider
{
    private readonly ICsvReader _csvReader;
    public CsvProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }
    public void GenerateDataFromCsvFile()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufactures = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        GroupManufacturesByAverage(cars);


    }

    private void GroupManufacturesByAverage(List<Car> cars)
    {
        var groups = cars
            .GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Average = g.Average(c => c.Combined),

            })
            .OrderBy(x => x.Average);
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\t Max:{group.Max:N2}");
            Console.WriteLine($"\t Average:{group.Average:N2}");
        }
    }
}
