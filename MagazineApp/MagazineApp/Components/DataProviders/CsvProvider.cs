
using System.Xml.Linq;
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

    public List<Pharmacies> GeneratePharmaceries()
    {
        return _csvReader.ProcessPharmacies("Resources\\Files\\Pharmacies.csv");
    }

    public void GenerateXml()
    {
        var carsRecords = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturesRecords = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var groups = manufacturesRecords.GroupJoin(
            carsRecords,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {
                Manufacturer = m,
                Cars = g,
            })
            .OrderBy(x => x.Manufacturer.Name);


        var document = new XDocument();
        var manufactures = new XElement("Manufacturers", groups
            .Select(x =>
            new XElement("Manufacturer",
                new XAttribute("Name", x.Manufacturer.Name),
                new XAttribute("Country", x.Manufacturer.Country),
                     new XElement("Cars",
                        new XAttribute("Country", x.Manufacturer.Country),
                        new XAttribute("CombinedSum", x.Cars.Sum(x => x.Combined)),
                      new XElement("Car", x.Cars
                         .Select(x =>
                         new XElement("Car",
                           new XAttribute("Model", x.Name),
                            new XAttribute("Combined", x.Combined))))))));

        document.Add(manufactures);
        document.Save("manufacturers.xml");
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
