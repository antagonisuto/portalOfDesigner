using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace courseProject.Controllers
{
    public class BooksInventoryController : Controller
    {
        private readonly AppDBContext _context;

        public BooksInventoryController(AppDBContext context)
        {
            _context = context;
        }

        // GET: UserAnswers
        public async Task<IActionResult> Index()
        {
            var myContext = _context.BooksInventories.Include(u => u.Book).Include(u => u.User);
            return View(await myContext.ToListAsync());
        }

        // GET: UserAnswers/Details/5
        public async Task<IActionResult> Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.BooksInventories.FindAsync(id1, id2);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }
        // GET: UserAnswers/Create
        public IActionResult Create()
        {
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title");
            ViewData["Author_id"] = new SelectList(_context.Userss, "User_id", "FullName");
            return View();
        }

        // POST: UserAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,User_id")] BooksInventory user_Answers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Answers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title", user_Answers.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "FullName", user_Answers.User_id);
            return View(user_Answers);
        }

        // GET: UserAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.BooksInventories.FindAsync(id1, id2);
            if (user_Answers == null)
            {
                return NotFound();
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title", user_Answers.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "FullName", user_Answers.User_id);
            return View(user_Answers);
        }

        // POST: UserAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,SurveyId")] BooksInventory user_Answers)
        {

            if (ModelState.IsValid)
            {

                _context.Update(user_Answers);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title", user_Answers.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "Full_name", user_Answers.User_id);
            return View(user_Answers);
        }

        // GET: UserAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.BooksInventories.FindAsync(id1, id2);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }
        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id1, int id2)
        {
            var user_Answers = await _context.BooksInventories.FindAsync(id1, id2);
            _context.BooksInventories.Remove(user_Answers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_AnswersExists(int id)
        {
            return _context.BooksInventories.Any(e => e.User_id == id);
        }
    }
}