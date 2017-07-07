using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public JobOpeningsController(JobHuntContext context)
        {
            _context = context;    
        }

        // GET: JobOpenings
        public async Task<IActionResult> Index()
        {
            ViewData["companyList"] = _context.Companies.ToList();

            return View(await _context.JobOpenings.ToListAsync());
        }

        // GET: JobOpenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOpening = await _context.JobOpenings.SingleOrDefaultAsync(m => m.JobOpeningID == id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            return View(jobOpening);
        }

        // GET: JobOpenings/Create
        public IActionResult Create()
        {
            ViewData["companyList"] = _context.Companies.ToList();
            return View();
        }

        // POST: JobOpenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName, CompanyID, CompanyUrl, JobOpeningTitle,JobOpeningRecorded,JobOpeningSource,JobOpeningUrl,JobOpeningDescription,JobOpeningNotes,JobOpeningActive")] AddJobOpeningViewModel jobOpening)
        {
            if (ModelState.IsValid)
            {
                HistoryItem tempHistoryItem;

                Company newCompany;
                if (jobOpening.CompanyName != "")
                {
                    //Create the company record
                    newCompany = new Company() {
                        CompanyName = jobOpening.CompanyName,
                        CompanyActive = true,
                        CompanyUrl = jobOpening.CompanyUrl                    
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
                        HistoryItemText = newCompany.CompanyName + " was added."
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
                    JobOpeningActive = true
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
                    HistoryItemText = ""
                };
                _context.HistoryItems.Add(tempHistoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobOpening);
        }

        // GET: JobOpenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOpening = await _context.JobOpenings.SingleOrDefaultAsync(m => m.JobOpeningID == id);
            if (jobOpening == null)
            {
                return NotFound();
            }
            return View(jobOpening);
        }

        // POST: JobOpenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobOpeningID,CompanyID,JobOpeningTitle,JobOpeningRecorded,JobOpeningSource,JobOpeningUrl,JobOpeningDescription,JobOpeningNotes,JobOpeningActive")] JobOpening jobOpening)
        {
            if (id != jobOpening.JobOpeningID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
    }
}
