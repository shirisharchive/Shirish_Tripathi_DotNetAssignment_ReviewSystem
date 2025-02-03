using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shirish_Tripathi_Dot_Net_Assignment.Data;
using Shirish_Tripathi_Dot_Net_Assignment.Models;

namespace Shirish_Tripathi_Dot_Net_Assignment.Controllers
{
    public class ReviewSubmitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewSubmitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReviewSubmits
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReviewSubmit.ToListAsync());
        }

        // GET: ReviewSubmits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewSubmit = await _context.ReviewSubmit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewSubmit == null)
            {
                return NotFound();
            }

            return View(reviewSubmit);
        }

        // GET: ReviewSubmits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewSubmits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Feedback,StarRating")] ReviewSubmit reviewSubmit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewSubmit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewSubmit);
        }

        // GET: ReviewSubmits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewSubmit = await _context.ReviewSubmit.FindAsync(id);
            if (reviewSubmit == null)
            {
                return NotFound();
            }
            return View(reviewSubmit);
        }

        // POST: ReviewSubmits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Feedback,StarRating")] ReviewSubmit reviewSubmit)
        {
            if (id != reviewSubmit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewSubmit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewSubmitExists(reviewSubmit.Id))
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
            return View(reviewSubmit);
        }

        // GET: ReviewSubmits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewSubmit = await _context.ReviewSubmit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewSubmit == null)
            {
                return NotFound();
            }

            return View(reviewSubmit);
        }

        // POST: ReviewSubmits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewSubmit = await _context.ReviewSubmit.FindAsync(id);
            if (reviewSubmit != null)
            {
                _context.ReviewSubmit.Remove(reviewSubmit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewSubmitExists(int id)
        {
            return _context.ReviewSubmit.Any(e => e.Id == id);
        }
    }
}
