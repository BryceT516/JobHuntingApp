using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using JobHuntingApp.Models;
using JobHuntingApp.ViewModels;
using JobHuntingApp.Data;

namespace JobHuntingApp.Controllers
{
    public class HomeController : Controller
    {
        private JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(JobHuntContext context, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;            
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if(user == null)
            {
                return View("Error");
            }
            //Get the list of job openings into the Dashboard Viewmodel

            var JobOpeningsList = (from jobOpenings in _context.JobOpenings
                                   join companies in _context.Companies on jobOpenings.CompanyID equals companies.CompanyID into group1
                                   from g1 in group1.DefaultIfEmpty()
                                   where jobOpenings.UserID == user.Id
                                   orderby jobOpenings.JobOpeningRecorded
                                   select new DashboardViewModel
                                   {
                                       JobOpeningTitle = jobOpenings.JobOpeningTitle,
                                       CompanyName = g1.CompanyName,
                                       CompanyID = g1.CompanyID,
                                       CompanyNotes = g1.CompanyNotes,
                                       CompanyUrl = g1.CompanyUrl,
                                       JobOpeningID = jobOpenings.JobOpeningID,
                                       JobOpeningDescription = jobOpenings.JobOpeningDescription,
                                       JobOpeningNotes = jobOpenings.JobOpeningNotes,
                                       JobOpeningRecorded = jobOpenings.JobOpeningRecorded,
                                       JobOpeningSource = jobOpenings.JobOpeningSource,
                                       JobOpeningUrl = jobOpenings.JobOpeningUrl,
                                       UserID = jobOpenings.UserID
                                   }).ToList();

            ViewData["People"] = _context.People.Where(p => p.UserID == user.Id).ToList();
            ViewData["CoverLetters"] = _context.CoverLetters.Where(cl => cl.UserID == user.Id).ToList();
            ViewData["Applications"] = _context.Applications.Where(ap => ap.UserID == user.Id).ToList();
            ViewData["Resumes"] = _context.Resumes.Where(r => r.UserID == user.Id).ToList();

            return View(JobOpeningsList);
        }


        public IActionResult Error()
        {
            return View();
        }


        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }



    }
}
