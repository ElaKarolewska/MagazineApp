using MagazineApp.Entities;

namespace MagazineApp.Repositories;

public interface IRepository <T> : IWriteRepository<T>, IReadRepository<T>
	  where T : class, IEntity
{
}


