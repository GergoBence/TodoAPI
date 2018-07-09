using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{
    public class TodoRepository
    {
        public List<Todo> list = new List<Todo>();

      

        public List<Todo> GetAll()
        {
            if (list.Count < 1)
            {
                GenerateList();
            }
            return list;
        }

        public void GenerateList()
        {
            for (int i = 0; i < 3; i++)
            {
                var item = new Todo();
                item.Content = i.ToString();
                Random rnd = new Random();
                var a = rnd.Next(1, 100);
                list.Add(new Todo { ID = i, Content = "Content "+a, Done = false });
            }
        }

        public void Delete(int id)
        {
            
        }

        public Todo GetTodo(int id)
        {
            return list.SingleOrDefault(x => x.ID == id);
        }

        public void UpdateTodo(Todo todo)
        {
            var oldTodo = list.SingleOrDefault(x => x.ID == todo.ID);
            if (oldTodo!=null)
            {
                list.Remove(oldTodo);
                list.Add(todo);
            }
        }

        public void DeleteTodo(int iD)
        {
            var oldModel = list.SingleOrDefault(x => x.ID == iD);
            if (oldModel!=null)
            {
                list.Remove(oldModel);
            }
        }

        internal void AddTodo(Todo td)
        {
            td.ID = list.Last().ID++;
            list.Add(td);
        }
    }
}