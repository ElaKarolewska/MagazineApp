using MagazineApp.Components.DataProviders;
using System.Xml.Linq;

namespace MagazineApp;

public class AppCsv : IApp
{
    private readonly ICsvProvider _csvProvider;
    public AppCsv(ICsvProvider csvProvider)
    {
        _csvProvider = csvProvider;
    }
    public void Run()
    {
        _csvProvider.GenerateDataFromCsvFile();

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
}
