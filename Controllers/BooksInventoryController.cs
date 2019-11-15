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

        
        // GET: UserAnswers/Create
        public IActionResult Create()
        {
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title");
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "User_id");
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
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "User_id", user_Answers.User_id);
            return View(user_Answers);
        }

        // GET: UserAnswers/Edit/5
        public async Task<IActionResult> Update(int? id1, int? id2)
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
            ViewData["Book_id"] = new SelectList(_context.Books, "id1", "Book_id", user_Answers.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "id2", "User_id", user_Answers.User_id);
            return View(user_Answers);
        }


        //[HttpPost]
        //public async Task<IActionResult> Update(int id, [Bind("Book_id,User_id")] BooksInventory user_Answers)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        _context.Update(user_Answers);
        //        await _context.SaveChangesAsync();


        //    }
        //    ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_id", user_Answers.Book_id);
        //    ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "User_id", user_Answers.User_id);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Book_id,User_id")] BooksInventory courseMember)
        {

            if (ModelState.IsValid)
            {

                _context.Update(courseMember);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));

            }
            ViewData["Book_id"] = new SelectList(_context.Books, "id", "id", courseMember.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "id", "id", courseMember.User_id);
            return View(courseMember);
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
        public async Task<IActionResult> Delete(int Book_id, int User_id)
        {
            var user_Answers = await _context.BooksInventories.FindAsync(Book_id, User_id);
            _context.BooksInventories.Remove(user_Answers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}