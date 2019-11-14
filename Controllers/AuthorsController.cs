using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class AuthorsController : Controller
    {
        public readonly AppDBContext _context;

        public AuthorsController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Authors teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Index()
        {
            return View(_context.Authors);
        }

        public IActionResult Update(int id)
        {
            return View(_context.Authors.Where(a => a.Author_id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Authors author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _context.Authors.Where(a => a.Author_id == id).FirstOrDefault();
            _context.Authors.Remove(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
