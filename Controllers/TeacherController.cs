using dotnet.Data;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;

namespace dotnet.Controllers
{
    public class TeacherController: Controller
    {
        private readonly ApplicationDbContext context;

        public TeacherController(ApplicationDbContext context)
        {
            this.context = context;
        }
         public IActionResult Index()
        {
           return View( context.Teachers.ToList());
        }

        [HttpGet]
        public IActionResult New()
        {
           // var student = new Student();
            return View(new Teacher());
        }

        [HttpPost]
        public IActionResult New(Teacher vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Add (vm);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var subject = context.Teachers.Find(id);
            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(int id, Teacher teachers)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update (teachers);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var subject = context.Teachers.Find(id);
            context.Remove (subject);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}