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
    public class ApplicationsController : Controller
    {
        private readonly JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationsController(JobHuntContext context, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            return View(await _context.Applications.Where(x => x.UserID == user.Id).ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .SingleOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            ViewData["resumeList"] = _context.Resumes.Where(r => r.UserID == user.Id).ToList();
            ViewData["jobsList"] = _context.JobOpenings.Where(j => j.UserID == user.Id && j.JobOpeningActive == true).ToList();
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,JobID,ApplicationSubmitted,ApplicationMethod, ResumeID")] Application application)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                application.UserID = user.Id;
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Edit/5
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

            var application = await _context.Applications.SingleOrDefaultAsync(m => m.ApplicationID == id && m.UserID==user.Id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,JobID,ApplicationSubmitted,ApplicationMethod")] Application application)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id != application.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    application.UserID = user.Id;
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationID))
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
            return View(application);
        }

        // GET: Applications/Delete/5
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

            var application = await _context.Applications
                .SingleOrDefaultAsync(m => m.ApplicationID == id && m.UserID==user.Id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            var application = await _context.Applications.SingleOrDefaultAsync(m => m.ApplicationID == id && m.UserID==user.Id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationID == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }


    }
}
