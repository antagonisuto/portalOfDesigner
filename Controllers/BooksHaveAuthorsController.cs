using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class BooksHaveAuthorsController : Controller
    {
        public readonly AppDBContext _context;

        public BooksHaveAuthorsController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var BHA = _context.BooksHaveAuthors.Include(c => c.Book).Include(c => c.Authors);
            return View(await BHA.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title");
            ViewData["Author_id"] = new SelectList(_context.Authors, "Author_id", "Author_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,Author_id")] BooksHaveAuthors BHA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(BHA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_id", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(_context.Authors, "Author_id", "Author_id", BHA.Author_id);
            return View(BHA);
        }

        public async Task<IActionResult> Update(int? id1, int? id2)
        {
            
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var BHA = await _context.BooksHaveAuthors.FindAsync(id1, id2);
            if (BHA == null)
            {
                return NotFound();
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "id", "Book_id", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(_context.Authors, "id", "Author_id", BHA.Author_id);
            return View(BHA);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Book_id,Author_id")] BooksHaveAuthors BHA)
        {

            if (ModelState.IsValid)
            {
                _context.Update(BHA);
                await _context.SaveChangesAsync();
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_id", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(_context.Authors, "Author_id", "Author_id", BHA.Author_id);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.BooksHaveAuthors.FindAsync(id1, id2);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }

        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int Book_id, int User_id)
        {
            var user_Answers = await _context.BooksHaveAuthors.FindAsync(Book_id, User_id);
            _context.BooksHaveAuthors.Remove(user_Answers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
