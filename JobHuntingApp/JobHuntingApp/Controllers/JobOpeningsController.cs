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
using JobHuntingApp.ViewModels;

namespace JobHuntingApp.Controllers
{    
    public class JobOpeningsController : Controller
    {
        private readonly JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JobOpeningsController(JobHuntContext context, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        // GET: JobOpenings
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            ViewData["companyList"] = await _context.Companies.Where(x => x.UserID == user.Id).ToListAsync();

            return View(await _context.JobOpenings.Where(x => x.UserID == user.Id).ToListAsync());
        }

        [Authorize]
        // GET: JobOpenings/Details/5
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

            ViewData["companyInfo"] = _context.Companies.Where(c => c.UserID == user.Id).ToList();

            var jobOpening = await _context.JobOpenings.SingleOrDefaultAsync(m => m.JobOpeningID == id && m.UserID==user.Id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            return View(jobOpening);
        }

        [Authorize]
        // GET: JobOpenings/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            ViewData["companyList"] = _context.Companies.Where(x=> x.UserID == user.Id).ToList();
            return View();
        }

        [Authorize]
        // POST: JobOpenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName, CompanyID, CompanyUrl, JobOpeningTitle,JobOpeningRecorded,JobOpeningSource,JobOpeningUrl,JobOpeningDescription,JobOpeningNotes,JobOpeningActive")] AddJobOpeningViewModel jobOpening)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                if (user == null)
                {
                    return View("Error");
                }

                HistoryItem tempHistoryItem;
                               

                Company newCompany;
                if (jobOpening.CompanyName != null)
                {
                    //Create the company record
                    newCompany = new Company() {
                        CompanyName = jobOpening.CompanyName,
                        CompanyActive = true,
                        CompanyUrl = jobOpening.CompanyUrl,
                        UserID = user.Id
                    };
                    _context.Add(newCompany);
                    await _context.SaveChangesAsync();
                    //Get the company ID
                    await _context.Entry(newCompany).GetDatabaseValuesAsync();
                    //Update the historyitem
                    tempHistoryItem = new HistoryItem() {
                        HistoryItemCreated = DateTime.Now,
                        HistoryItemDate = DateTime.Now,
                        HistoryItemEvent = "Company Created",
                        CompanyID = newCompany.CompanyID,
                        HistoryItemText = newCompany.CompanyName + " was added.",
                        UserID = user.Id
                    };
                    _context.HistoryItems.Add(tempHistoryItem);
                    await _context.SaveChangesAsync();
                    
                }
                else
                {
                    // Use the selected Company
                    newCompany = _context.Companies.SingleOrDefault(x => x.CompanyID == jobOpening.CompanyID);
                }
                
                //Create the job opening record
                var newJobOpening = new JobOpening()
                {
                    CompanyID = newCompany.CompanyID,
                    JobOpeningTitle = jobOpening.JobOpeningTitle,
                    JobOpeningDescription = jobOpening.JobOpeningDescription,
                    JobOpeningNotes = jobOpening.JobOpeningNotes,
                    JobOpeningUrl = jobOpening.JobOpeningUrl,
                    JobOpeningRecorded = DateTime.Now,
                    JobOpeningSource = jobOpening.JobOpeningSource,
                    JobOpeningActive = true,
                    UserID = user.Id
                };
                _context.Add(newJobOpening);
                await _context.SaveChangesAsync();
                //Get the job ID
                await _context.Entry(newJobOpening).GetDatabaseValuesAsync();
                //Create historical item
                tempHistoryItem = new HistoryItem()
                {
                    HistoryItemCreated = DateTime.Now,
                    HistoryItemDate = DateTime.Now,
                    HistoryItemEvent = "Job Opening Created",
                    JobID = newJobOpening.JobOpeningID,
                    HistoryItemText = "",
                    UserID = user.Id
                };
                _context.HistoryItems.Add(tempHistoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobOpening);
        }

        [Authorize]
        // GET: JobOpenings/Edit/5
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
            ViewData["companyList"] = _context.Companies.Where(c => c.UserID == user.Id).ToList();
            var jobOpening = await _context.JobOpenings.SingleOrDefaultAsync(m => m.JobOpeningID == id && m.UserID == user.Id);
            if (jobOpening == null)
            {
                return NotFound();
            }
            return View(jobOpening);
        }

        [Authorize]
        // POST: JobOpenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobOpeningID,CompanyID,JobOpeningTitle,JobOpeningRecorded,JobOpeningSource,JobOpeningUrl,JobOpeningDescription,JobOpeningNotes,JobOpeningActive")] JobOpening jobOpening)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (id != jobOpening.JobOpeningID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jobOpening.UserID = user.Id;
                    _context.Update(jobOpening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOpeningExists(jobOpening.JobOpeningID))
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
            return View(jobOpening);
        }

        [Authorize]
        // GET: JobOpenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOpening = await _context.JobOpenings
                .SingleOrDefaultAsync(m => m.JobOpeningID == id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            return View(jobOpening);
        }

        [Authorize]
        // POST: JobOpenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobOpening = await _context.JobOpenings.SingleOrDefaultAsync(m => m.JobOpeningID == id);
            _context.JobOpenings.Remove(jobOpening);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobOpeningExists(int id)
        {
            return _context.JobOpenings.Any(e => e.JobOpeningID == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }


    }
}
