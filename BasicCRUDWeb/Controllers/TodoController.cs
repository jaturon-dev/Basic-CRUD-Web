using BasicCRUDWeb.Controllers.Data;
using BasicCRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUDWeb.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TodoController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var objTodoLists = _db.TodoLists.ToList();
            IEnumerable<Todo> objTodoLists = _db.TodoLists.OrderByDescending(Todo => Todo.Priority);

            ViewData["todo"] = "active";

            return View(objTodoLists);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Todo obj, int prio)
        {
            if (ModelState.IsValid) 
            {
                //if (obj.Dolist.Length <= 500)
                //{
                //    obj.Priority = prio;
                //    _db.TodoLists.Add(obj);
                //    _db.SaveChanges();
                //}
                obj.Priority = prio;
                _db.TodoLists.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var todofromdb = _db.TodoLists.Find(id);

            if (todofromdb == null) 
            {
                return NotFound();
            }
            return View(todofromdb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Todo obj, int prio)
        {
            if (ModelState.IsValid)
            {
                obj.Priority = prio;
                _db.TodoLists.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var todofromdb = _db.TodoLists.Find(id);

            if (todofromdb == null)
            {
                return NotFound();
            }

            _db.TodoLists.Remove(todofromdb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
