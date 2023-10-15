using MagazineApp.Entities;

namespace MagazineApp.Repositories;

public interface IWriteRepository <in T> where T : class, IEntity
{
    void Add(T item, bool prescriptionDrug);
    void Remove (T item);
    void Save();
}
