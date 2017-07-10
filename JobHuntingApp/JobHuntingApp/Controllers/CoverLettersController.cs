using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

namespace JobHuntingApp.Controllers
{
    [Authorize]
    public class CoverLettersController : Controller
    {
        private readonly JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CoverLettersController(JobHuntContext context, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: CoverLetters
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            return View(await _context.CoverLetters.Where(x => x.UserID == user.Id).ToListAsync());
        }

        // GET: CoverLetters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id && m.UserID==user.Id);
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
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                coverLetter.UserID = user.Id;
                _context.Add(coverLetter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coverLetter);
        }

        // GET: CoverLetters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id && m.UserID==user.Id);
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
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id != coverLetter.CoverLetterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    coverLetter.UserID = user.Id;
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
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters
                .SingleOrDefaultAsync(m => m.CoverLetterID == id && m.UserID==user.Id);
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
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id && m.UserID==user.Id);
            _context.CoverLetters.Remove(coverLetter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoverLetterExists(int id)
        {
            return _context.CoverLetters.Any(e => e.CoverLetterID == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
