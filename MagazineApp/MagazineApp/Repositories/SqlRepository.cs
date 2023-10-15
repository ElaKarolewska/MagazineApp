﻿using MagazineApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagazineApp.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    
    public SqlRepository( DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    public void Add(T item, bool prescriptionDrug)
    {
       _dbSet.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public T GetById(int id)
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
