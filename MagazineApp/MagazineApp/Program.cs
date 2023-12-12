using MagazineApp;
using MagazineApp.Components.CsvReader;
using MagazineApp.Components.CsvReader.Models;
using MagazineApp.Components.DataProviders;
using MagazineApp.Components.XmlReader;
using MagazineApp.Data;
using MagazineApp.Data.Entities;
using MagazineApp.Data.Repositories;
using MagazineApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Medicine>, SqlRepository<Medicine>>();
//services.AddSingleton<IRepository<Medicine>, FileRepository<Medicine>>();
services.AddSingleton<IMedicineProvider, MedicineProvider>();

services.AddSingleton<IPharmaciesData, PharmaciesData>();

services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlCreator, XmlCreator>();
services.AddSingleton<ICsvProvider, CsvProvider>();
services.AddSingleton<IPharmaciesProvider, PharmaciesProvider>();

services.AddDbContext<MagazineAppDbContext>(options => options
.UseSqlServer("Data Source = KAROL\\SQLEXPRESS; Initial Catalog = MagazineAppStorage; Integrated Security = True"));

services.AddDbContext<MagazineAppDbContext>(options => options
         .UseSqlServer("Data Source = KAROL\\SQLEXPRESS; Initial Catalog = Pharmacies; Integrated Security = True"));

services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, MagazineApp.Services.EventHandler>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();
