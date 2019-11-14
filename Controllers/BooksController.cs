using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class BooksController : Controller
    {
        public readonly AppDBContext _context;

        public BooksController(AppDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var courses = _context.Books.Include(c => c.Publishers);
            return View(await courses.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(e => e.Publishers)
                .FirstOrDefaultAsync(m => m.Pub_id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Create()
        {
            ViewData["Pub_id"] = new SelectList(_context.Publishers, "Pub_id", "Pub_id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,Book_title,Book_page,Book_pub,Book_shortDec,Book_dec,Pub_id")] Books book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["Pub_id"] = new SelectList(_context.Publishers, "Book_id", "Pub_id", book.Pub_id);
            return View(book);
        }


        // GET: Equipment/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["Pub_id"] = new SelectList(_context.Publishers, "Pub_id", "Pub_id", book.Pub_id);
            return View(book);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Books book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Book_id,Book_title,Book_page,Book_pub,Book_shortDec,Book_dec,Pub_id")]  Books book)
        {
            if (id != book.Book_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(book.Book_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Pub_id"] = new SelectList(_context.Publishers, "id", "id", book.Pub_id);
            return View(book);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Where(a => a.Book_id == id).FirstOrDefault();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Book_id == id);
        }
    }
}
