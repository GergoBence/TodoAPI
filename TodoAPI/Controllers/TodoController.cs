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
        TodoRepository _todoRepository = new TodoRepository();
        // GET: Todo

        //public ActionResult Index()
        //{
        //    ViewBag.Title = "TODO:";
        //    return View();
        //}



        public ActionResult Index()
        {
            
            var td = _todoRepository.GetAll();
            return View(td);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todo = _todoRepository.GetTodo(id);
            var td = todo;
            //TODO: szerkesztési adatok Get
            
            return View(td);
        }
        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            //TODO: Szerkesztési adatok Post
            var td = todo;
            _todoRepository.UpdateTodo(td);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var todo = _todoRepository.GetTodo(id);
            //TODO: Szerk A Delete
            var td = todo;
            return View(td);
        }
        [HttpPost]
        public ActionResult Delete(Todo todo)
        {
            _todoRepository.DeleteTodo(todo.ID);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new Todo());
        }
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            //TODO: Szek A Create
            var td = todo;

            _todoRepository.AddTodo(td);
            return RedirectToAction("Index");
        }

    }
}