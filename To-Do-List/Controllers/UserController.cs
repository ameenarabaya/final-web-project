using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
namespace To_Do_List.Controllers
{
    public class UserController : Controller
    {
        private ToDoContext context { get; set; }

        public UserController(ToDoContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            User namecheck = context.User.Where(m => m.Name == user.Name).FirstOrDefault();
            User Emailcheck = context.User.Where(m => m.Email == user.Email).FirstOrDefault();
            User Passcheck = context.User.Where(m => m.Password == user.Password).FirstOrDefault();
            if (namecheck == null)
            {
                ViewBag.Error = "invalid Name";
                return View();
            }
            else if (Emailcheck == null)
            {
                ViewBag.Error = "invalid Email";
                return View();
            }
            else if (Passcheck == null)
            {
                ViewBag.Error = "invalid Password";

                return View();
            }
            else
            {
                User u = context.User.Where(m => (m.Name == user.Name && m.Email == user.Email && m.Password == user.Password))
                    .FirstOrDefault();
                if (u != null)
                {
                    //successful login
                    HttpContext.Session.SetInt32("UserId", u.Id);

                    HttpContext.Session.SetString("UserName", u.Name);

                    return RedirectToAction("Index", "Task", user);
                }
                return View();
            }

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (context.User.Any(m => m.Id == user.Id))
            {
                return View("Index");
            }
            else
            {
                context.User.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index", "User");
            }

        }
        public IActionResult Logout()

        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }
    }
}
