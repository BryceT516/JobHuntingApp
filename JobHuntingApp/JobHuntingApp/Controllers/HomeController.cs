using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobHuntingApp.Models;
using JobHuntingApp.ViewModels;
using JobHuntingApp.Data;

namespace JobHuntingApp.Controllers
{
    public class HomeController : Controller
    {
        private JobHuntContext _context;

        public HomeController(JobHuntContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Get the list of job openings into the Dashboard Viewmodel
            
            var JobOpeningsList = (from jobOpenings in _context.JobOpenings
                                   join companies in _context.Companies on jobOpenings.CompanyID equals companies.CompanyID into group1
                                   from g1 in group1.DefaultIfEmpty()

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
                                       JobOpeningUrl = jobOpenings.JobOpeningUrl                                       
                                   }).ToList();

            ViewData["People"] = _context.People.ToList();
            ViewData["CoverLetters"] = _context.CoverLetters.ToList();
            ViewData["Applications"] = _context.Applications.ToList();

            return View(JobOpeningsList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
