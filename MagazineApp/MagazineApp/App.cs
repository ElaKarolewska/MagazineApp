using MagazineApp.Components.CsvReader;
using MagazineApp.Components.CsvReader.Models;
using MagazineApp.Components.DataProviders;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;
using System.Xml.Linq;

namespace MagazineApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader; 
    //private readonly IUserCommunication _userCommunication;
    //private readonly IEventHandler _eventHandler;
    public App(IRepository<Medicine> medicineRepository, IMedicineProvider medicineProvider,IUserCommunication userCommunication,
              IEventHandler eventHandler, ICsvReader csvReader)
    {
          _csvReader = csvReader;
        //_eventHandler = eventHandler;
       // _userCommunication = userCommunication;
    }
    public void Run()
    {
        // _eventHandler.Subscribe();
        // _userCommunication.ChooseWhatToDo();

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