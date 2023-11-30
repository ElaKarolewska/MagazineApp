using MagazineApp.Components.DataProviders;

namespace MagazineApp;

public class AppCsv : IApp
{
    private readonly ICsvProvider _csvProvider;
    private readonly IPharmaceriesProvider _pharmaceriesProvider;
    public AppCsv(ICsvProvider csvProvider, IPharmaceriesProvider pharmaceriesProvider)
    {
        _csvProvider = csvProvider;
        _pharmaceriesProvider = pharmaceriesProvider;
    }
    public void Run()
    {
      //  _csvProvider.GenerateXml();

      //  _csvProvider.GenerateDataFromCsvFile();
        var pharmaceries = _csvProvider.GeneratePharmaceries();

        var pharmaceriesOrderedByName = _pharmaceriesProvider.OrderByName(pharmaceries);
    }
}
