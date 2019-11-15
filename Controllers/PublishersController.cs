using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class PublishersController : Controller
    {

        public readonly AppDBContext _context;

        public PublishersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Publishers);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Publishers
                .FirstOrDefaultAsync(m => m.Pub_id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publishers pub)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(pub);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(int id)
        {
            return View(_context.Publishers.Where(a => a.Pub_id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Publishers pub)
        {
            _context.Publishers.Update(pub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pub = _context.Publishers.Where(a => a.Pub_id == id).FirstOrDefault();
            _context.Publishers.Remove(pub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
