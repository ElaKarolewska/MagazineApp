using MagazineApp;
using MagazineApp.Components.CsvReader;
using MagazineApp.Components.DataProviders;
using MagazineApp.Components.XmlReader;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Medicine>, FileRepository<Medicine>>();
services.AddSingleton<IMedicineProvider, MedicineProvider>();

services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlCreator, XmlCreator>();
services.AddSingleton<ICsvProvider, CsvProvider>();

services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, MagazineApp.Services.EventHandler>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();



