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
    public class BooksRequestsController : Controller
    {
        private readonly AppDBContext _context;

        public BooksRequestsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var myContext = _context.BooksRequests.Include(u => u.Book).Include(u => u.User);
            return View(await myContext.ToListAsync());
        }

        // GET: UserAnswers/Create
        public IActionResult Create()
        {
            ViewData["Book_id"] = new SelectList(_context.Books, "Book_id", "Book_title");
            ViewData["User_id"] = new SelectList(_context.Userss, "User_id", "User_id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,User_id,RequestDate")] BooksRequests courseMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Book_id"] = new SelectList(_context.Books, "id", "id", courseMember.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "id", "id", courseMember.User_id);
            return View(courseMember);
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
            ViewData["Book_id"] = new SelectList(_context.Books, "id", "id", user_Answers.Book_id);
            ViewData["User_id"] = new SelectList(_context.Userss, "id", "id", user_Answers.User_id);
            return View(user_Answers);
        }

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
    }
}
