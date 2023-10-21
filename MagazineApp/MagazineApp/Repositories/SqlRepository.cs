﻿using MagazineApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback;
    public SqlRepository( DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }
   
    public event EventHandler<T>? ItemAdded;
    public void Add(T item)
    {
       _dbSet.Add(item);
       _itemAddedCallback?.Invoke(item);
        ItemAdded?.Invoke(this, item);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
