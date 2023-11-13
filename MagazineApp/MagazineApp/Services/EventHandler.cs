
using MagazineApp.Entities;
using MagazineApp.Repositories;

namespace MagazineApp.Services;

public class EventHandler : IEventHandler
{
    private readonly IRepository<Medicine> _medicineRepository;
    public EventHandler(IRepository<Medicine> medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }
    public void Subscribe()
    {
        _medicineRepository.ItemAdded += MedicineRepositoryOnItemAdded;
        _medicineRepository.ItemRemoved += MedicineRepositoryOnItemRemoved;
    }

    private void MedicineRepositoryOnItemAdded(object? sender, Medicine e)
    {
        Console.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} - {e.Name} {e.Dose} from {sender?.GetType().Name}");

           var auditFile = File.AppendText(@"auditMedicine.txt");
            using (auditFile)
            {
                auditFile.WriteLine($"Date:{DateTime.Now} Medicine added: {e.Id} -  {e.Name} {e.Dose}");
            }
    }

    private void MedicineRepositoryOnItemRemoved(object? sender, Medicine e)
    {
        Console.WriteLine($"Date:{DateTime.Now} Medicine removed: {e.Id} - {e.Name} {e.Dose}");
            var auditFile = File.AppendText(@"auditMedicine.txt");
            using (auditFile)
            {
               auditFile.WriteLine($"Date: {DateTime.Now} Medicine removed: {e.Id} - {e.Name} {e.Dose}");
            }
    }
}
