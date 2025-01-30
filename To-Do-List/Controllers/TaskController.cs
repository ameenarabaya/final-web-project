using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;


namespace To_Do_List.Controllers
{

    public class TaskController : Controller
    {
        private ToDoContext context { get; set; }

        public TaskController(ToDoContext ctx) => context = ctx;
        public IActionResult Index(User user)
        {

            //List<TaskModel> tasks= context.Tasks.Where(m => m.UserId==user.Id).ToList();

            ViewBag.color = new List<string> { "aquamarine", "#ffde59", "#c9b8da", "#ff914d", "#AEC33A" };

            var userId = HttpContext.Session.GetInt32("UserId");

            ViewBag.id = userId;
           
                String userName = HttpContext.Session.GetString("UserName");

                ViewBag.userName = userName;
          
           
            List<TaskModel> tasks = context.Tasks.Include(m => m.SubTasks).Where(m => m.UserId == userId).ToList();
            

            return View("Task",tasks);
        }
        [HttpGet]
        public IActionResult AddTask(User user)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            return View("AddTask");
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            context.Tasks.Add(task);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteTask(int id)
        {
            var task = context.Tasks.FirstOrDefault(m => m.Id == id);

            if (task == null)
            {
                return NotFound("Task not found.");
            }

            context.Tasks.Remove(task);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            var task = context.Tasks.FirstOrDefault(m => m.Id == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult EditTask(TaskModel task)
        {
           
            context.Tasks.Update(task);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddSubTask(int id)
        {
  
            ViewBag.TaskModelId = id;
            return View("AddSubTask");
        }

      
        [HttpPost]
        public IActionResult AddSubTask(SubTask task)
        {
            if (task == null)
            {
                return NotFound("Task not found.");
            }

           
            task.Id = 0;

            context.SubTask.Add(task);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       
             public IActionResult DeleteSubTask(int id)
        {
            var theSubTask = context.SubTask.FirstOrDefault(m => m.Id == id);

            if (theSubTask == null)
            {
                return NotFound("Task not found.");
            }

            context.SubTask.Remove(theSubTask);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSubTask(int id)
        {
            
            ViewBag.subTaskId = id;
            var task = context.SubTask.FirstOrDefault(m => m.Id == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult EditSubTask(SubTask task)
        {

            context.SubTask.Update(task);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
