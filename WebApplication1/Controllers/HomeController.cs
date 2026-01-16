using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ToDoList.Models;
using UseCases;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private ToDoListManager _listManager;

        public HomeController(ToDoListManager listManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _listManager = listManager;

        }

        public IActionResult Index(string searchString)
        {

            var toDoItems = _listManager.getToDoItem();

            if (string.IsNullOrEmpty(searchString) == false)
            {
                toDoItems = toDoItems.Where(ti => ti.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(new TodoListViewModel()
            {
                Items = toDoItems.Select(ti => new Item()
                {
                    Id = ti.Id,
                    Text = ti.Text,
                    isCompleted = ti.isCompleted
                })
            });

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");

        }

       [HttpPost]
        public IActionResult Add(Item item)
        {
            _listManager.AddTodoItem(new ToDoItem()
            {
                Id = item.Id,
                Text = item.Text,
                isCompleted = false
            });

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _listManager.Delete(id);
            

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(string id)
        {

            var toDoItems = _listManager.getToDoItem();
            if (string.IsNullOrEmpty(id) == false)
            {
                toDoItems = toDoItems.Where(ti => ti.Id == int.Parse(id));
            }

            return View(new ToDoItem()
            {
                Id = toDoItems.First().Id,
                Text = toDoItems.Last().Text,
                isCompleted = toDoItems.Last().isCompleted
            });
        }


        [HttpPost]
        public IActionResult Update(Item item)
        {
            _listManager.UpdateItem(new ToDoItem()
            {
                Id = item.Id,
                Text = item.Text,
                isCompleted = item.isCompleted
            } );
        
            return RedirectToAction("Index");
        }


        [HttpPost] 
        public IActionResult MarkComplete(int id)
        {
            _listManager.MarkComplete(id);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
