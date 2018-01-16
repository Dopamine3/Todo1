using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoFromDB.Repositories;
using TodoFromDB.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoFromDB.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController(TodoRepository todoRepository)
        {
            TodoRepository = todoRepository;
        }

        public TodoRepository TodoRepository { get; set; }

        [Route("")]
        public IActionResult LogIn()
        {
            return View();
        }

        [Route("Log")]
        public IActionResult Log(string username, string password)
        {
            if (username == "asd" && password == "asd")
            {
                return RedirectToAction("Todo");
            }
            return RedirectToAction("LogIn");
        }

        [Route("list")]
        public IActionResult Todo()
        {
            return View(TodoRepository.ListOfToDos());
        }

        [HttpGet("AddNew")]
        public IActionResult AddNew()
        {

            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(string Title)
        {
            Todo newTodo = new Todo()
            {
                Title = Title
            };
            TodoRepository.AddTodo(newTodo);
            return RedirectToAction("Todo");
        }

        [HttpPost("Remove")]
        public IActionResult Remove(long id)
        {
            TodoRepository.DeletTodo(id);

            return RedirectToAction("Todo");
        }

        [HttpGet("Update")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost("Upgrade")]
        public IActionResult Upgrade(string Title, bool IsDone, bool IsUrgent)
        {
            TodoRepository.Update(Title, IsDone, IsUrgent);
            return RedirectToAction("Todo");
        }
    }
}
