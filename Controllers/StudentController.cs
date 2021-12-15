using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using dotnet.Data;



namespace dotnet.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext context;

        public StudentController(ApplicationDbContext _context)
      {
            context = _context;
        }

        public IActionResult Index()
        {
           return View( context.Students.ToList());
        }

        [HttpGet]
        public IActionResult New()
        {
           // var student = new Student();
            return View(new Student());
        }

        [HttpPost]
        public IActionResult New(Student vm)
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
            if (id == null)
            {
                return NotFound();
            }
            var student = context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update (student);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Remove (student);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
