using MagazineApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Data.Repositories;
public class SqlRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    private readonly MagazineAppDbContext _magazineAppDbContext;
    private readonly DbSet<T> _dbSet;
    private List<T> _items = new();
    public SqlRepository(MagazineAppDbContext magazineAppDbContext)
    {
        _magazineAppDbContext = magazineAppDbContext;
        _magazineAppDbContext.Database.EnsureCreated();
        _dbSet = _magazineAppDbContext.Set<T>();
    }
    
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    public void Add(T item)
    {
       _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }
    public void Save()
    {
        _magazineAppDbContext.SaveChanges();
    }
    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }
}
