﻿using MagazineApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Data.Repositories;

public class SqlRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
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
        _dbContext.SaveChanges();
    }
    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }
}
