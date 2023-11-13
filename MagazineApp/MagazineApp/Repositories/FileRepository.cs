using MagazineApp.Entities;
using System.Text.Json;

namespace MagazineApp.Repositories;

public class FileRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    private List<T> _items = new();
    private readonly string path = $"{typeof(T).Name}_save.json";

    //private int lastUsedId = 1;
    public IEnumerable<T> GetAll()
    {
        ////return _items.ToList();
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects is not null)
            {
                _items = new List<T>();
                foreach (var items in deserializedObjects)
                {
                    _items.Add(items);
                }
            }
        }
        return _items;
    }
    public void Add(T item)
    {
        //if (_items.Count == 0)                       // to też dobrze działa
        //{
        //    item.Id = lastUsedId;
        //    lastUsedId++;
        //}
        //else if (_items.Count > 0)
        //{
        //    lastUsedId = _items[_items.Count - 1].Id;
        //    item.Id = ++lastUsedId;
        //}

        int newId;
        if (_items.Count == 0)
        {
            newId = 1;
        }
        else
        {
            var currentId = _items
               .OrderBy(item => item.Id)
               .Select(item => item.Id)
               .Last();
            newId = currentId + 1;
        }
        ////item.Id = _items.Count + 1;
        item.Id = newId;
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
    }
    public T? GetById(int id)
    {
        var itemById = _items.SingleOrDefault(item => item.Id == id);
        if (itemById == null) 
        {
            Console.WriteLine($"{typeof(T).Name} with ID {id} not found.");
        }

        return itemById;
        
        //return _items.Single(item => item.Id == id);
    }
    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        File.Delete(path);
        var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
        File.WriteAllText(path, objectsSerialized);
    }
    public IEnumerable<T> Read()
    {
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects is not null)
            {
                foreach (var item in deserializedObjects)
                {
                    _items.Add(item);
                }
            }

        }
        return _items;
    }
}


