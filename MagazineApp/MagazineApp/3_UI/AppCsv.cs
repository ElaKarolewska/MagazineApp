using MagazineApp.Components.DataProviders;

namespace MagazineApp;

public class AppCsv : IApp
{
    private readonly ICsvProvider _csvProvider;
    private readonly IPharmaciesProvider _pharmaciesProvider;
    public AppCsv(ICsvProvider csvProvider, IPharmaciesProvider pharmaciesProvider)
    {
        _csvProvider = csvProvider;
        _pharmaciesProvider = pharmaciesProvider;
    }
    public void Run()
    {
        var pharmacies = _csvProvider.GeneratePharmacies();

        var pharmaciesOrderByName = _pharmaciesProvider.OrderByName(pharmacies);
   
    }
}
