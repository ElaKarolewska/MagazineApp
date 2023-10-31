using MagazineApp.Entities;

namespace MagazineApp.Repositories;

public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T>
      where T : class, IEntity
{
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

}


