using dotnet.Data;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;

namespace dotnet.Controllers
{
    public class BookController: Controller
    {
        private readonly ApplicationDbContext context;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
         public IActionResult Index()
        {
           return View( context.Books.ToList());
        }

        [HttpGet]
        public IActionResult New()
        {
           // var student = new Student();
            return View(new Book());
        }

        [HttpPost]
        public IActionResult New(Book vm)
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
           
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update (book);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            context.Remove (book);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}