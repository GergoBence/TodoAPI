using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoAPI.Models;

namespace TodoAPI
{
    public class Repository<T>
        where T : Entity
    {
        private readonly TodoContext _todoContext;

        public Repository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public T Get(int id)
        {
            return _todoContext.Set<T>().FirstOrDefault(i => i.ID == id);
        }

        public List<T> GetAll()
        {
            return _todoContext.Set<T>().ToList();
        }

        public void Add(T item)
        {
            var table = _todoContext.Set<T>();
            table.Add(item);

            _todoContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _todoContext.Set<T>().Remove(item);
            _todoContext.SaveChanges();
        }

        public void ApplyChanges()
        {
            _todoContext.SaveChanges();
        }
    }
}