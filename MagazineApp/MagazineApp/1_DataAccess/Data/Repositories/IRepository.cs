using MagazineApp.Data.Entities;

namespace MagazineApp.Data.Repositories;

public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T>
      where T : class, IEntity
{
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
}


