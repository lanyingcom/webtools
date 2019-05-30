using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetY.Models;

namespace NetY.Controllers
{
    public class NewsClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsClass.ToListAsync());
        }

        // GET: NewsClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClass
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newsClass == null)
            {
                return NotFound();
            }

            return View(newsClass);
        }

        // GET: NewsClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClassName,ParentID,CreatedTime")] NewsClass newsClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsClass);
        }

        // GET: NewsClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClass.FindAsync(id);
            if (newsClass == null)
            {
                return NotFound();
            }
            return View(newsClass);
        }

        // POST: NewsClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClassName,ParentID,CreatedTime")] NewsClass newsClass)
        {
            if (id != newsClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsClassExists(newsClass.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsClass);
        }

        // GET: NewsClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClass
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newsClass == null)
            {
                return NotFound();
            }

            return View(newsClass);
        }

        // POST: NewsClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsClass = await _context.NewsClass.FindAsync(id);
            _context.NewsClass.Remove(newsClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsClassExists(int id)
        {
            return _context.NewsClass.Any(e => e.ID == id);
        }
    }
}
