using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity ////*, TKey>*/
    {
        //Why generic repository

        //public TKey? Key { get; set; }
        protected readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }
        public void Save()
        {
            foreach (var item in _items)
            {
                //already saved in list
            }
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
    //public class GenericRepositoryWithRemove<T> : GenericRepository<T>
    //    //we can define that for child class TKey is a string in that scenario we dont have to define next to child
    //    //class name
    //    //also we can add new generics parameters to the child class like TKey2 or sth
    //{
    //    public void Remove(T item)
    //    {
    //        _items.Remove(item);
    //    }
    //}
}
