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
    public class UserssController : Controller
    {
        public readonly AppDBContext _context;
      

        public UserssController(AppDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var courses = _context.Userss.Include(c => c.Role);
            return View(await courses.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Userss
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.Role_id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Create()
        {
            ViewData["Role_id"] = new SelectList(_context.Roles, "Role_id", "Role_id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("User_id,Username,Password,FullName,Role_id")] Userss user)
        {
            if (_context.Userss.Any(x => x.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username already in use");
            }
            if (ModelState.IsValid)
            {
                _context.Userss.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["Role_id"] = new SelectList(_context.Roles, "User_id", "Role_id", user.Role_id);
            return View(user);
        }


        // GET: Equipment/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Userss.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["Role_id"] = new SelectList(_context.Roles, "Role_id", "Role_id", book.Role_id);
            return View(book);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Userss book)
        {
            _context.Userss.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_id,Username,Password,FullName,Role_id")]  Userss book)
        {
            if (id != book.User_id)
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
                    if (!BooksExists(book.User_id))
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
            ViewData["Role_id"] = new SelectList(_context.Roles, "id", "id", book.Role_id);
            return View(book);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _context.Userss.Where(a => a.User_id == id).FirstOrDefault();
            _context.Userss.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool BooksExists(int id)
        {
            return _context.Userss.Any(e => e.User_id == id);
        }

        //VerifyUsername
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyUsername(string username)
        {
            if (_context.Userss.Any(m => m.Username.ToLower() == username.ToLower()))
            {
                return Json($"Username {username} is already in use.");
            }

            return Json(true);
        }

    }
}
