//using MagazineApp.Components.CsvReader;
//using System.Xml.Linq;

//namespace MagazineApp.Components.XmlReader;

//internal class XmlCreator : IXmlCreator
//{
//    private readonly ICsvReader _csvReader;

//    public XmlCreator(ICsvReader csvReader)
//    {
//        _csvReader = csvReader;
//    }
//    public void CreateXml()
//    {
//        var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

//        var document = new XDocument();

//        var cars = new XElement("Cars", records
//            .Select(x =>
//                 new XElement("Car",
//                     new XAttribute("Name", x.Name),
//                     new XAttribute("Combined", x.Combined),
//                     new XAttribute("Manufacturer", x.Manufacturer))));

//        document.Add(cars);
//        document.Save("fuel.xml");
//    }

//    public void QueryXml()
//    {
//        var document = XDocument.Load("fuel.xml");
//        var names = document
//            .Element("Cars")?
//            .Elements("Car")
//            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
//            .Select(x => x.Attribute("Name")?.Value);

//        foreach (var name in names)
//        {
//            Console.WriteLine(name);
//        }
//    }
//}
