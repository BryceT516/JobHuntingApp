using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

namespace JobHuntingApp.Controllers
{
    public class CoverLettersController : Controller
    {
        private readonly JobHuntContext _context;

        public CoverLettersController(JobHuntContext context)
        {
            _context = context;    
        }

        // GET: CoverLetters
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoverLetters.ToListAsync());
        }

        // GET: CoverLetters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters
                .SingleOrDefaultAsync(m => m.CoverLetterID == id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            return View(coverLetter);
        }

        // GET: CoverLetters/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: CoverLetters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoverLetterID,JobID,CoverLetterText")] CoverLetter coverLetter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coverLetter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coverLetter);
        }

        // GET: CoverLetters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id);
            if (coverLetter == null)
            {
                return NotFound();
            }
            return View(coverLetter);
        }

        // POST: CoverLetters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoverLetterID,JobID,CoverLetterText")] CoverLetter coverLetter)
        {
            if (id != coverLetter.CoverLetterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coverLetter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoverLetterExists(coverLetter.CoverLetterID))
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
            return View(coverLetter);
        }

        // GET: CoverLetters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters
                .SingleOrDefaultAsync(m => m.CoverLetterID == id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            return View(coverLetter);
        }

        // POST: CoverLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id);
            _context.CoverLetters.Remove(coverLetter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoverLetterExists(int id)
        {
            return _context.CoverLetters.Any(e => e.CoverLetterID == id);
        }
    }
}
