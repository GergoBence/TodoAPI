using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class TodoController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (var db = new TodoContext())
            {
                var repository = new Repository<Todo>(db);
                return Json(repository.GetAll(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post([Bind]Todo todo)
        {
            using (var db = new TodoContext())
            {
                var repository = new Repository<Todo>(db);
                repository.Add(todo);

                return Json(todo);
            }
        }

        [HttpPatch]
        public ActionResult Patch([Bind]Todo item)
        {
            using (var db = new TodoContext())
            {
                var repository = new Repository<Todo>(db);
                var todoInDb = repository.Get(item.ID);

                todoInDb.Content = item.Content;
                todoInDb.Done = item.Done;

                repository.ApplyChanges();

                return Json(item);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (var db = new TodoContext())
            {
                var repository = new Repository<Todo>(db);
                var item = repository.Get(id);
                repository.Delete(item);

                return Json(item);
            }
        }
    }
}