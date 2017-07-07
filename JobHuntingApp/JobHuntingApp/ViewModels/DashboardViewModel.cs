using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JobHuntingApp.Models;

namespace JobHuntingApp.ViewModels
{
    public class DashboardViewModel
    {
        //Job Opening
        public int JobOpeningID { get; set; }
        public string JobOpeningTitle { get; set; }
        public DateTime JobOpeningRecorded { get; set; }
        public string JobOpeningSource { get; set; }
        public string JobOpeningUrl { get; set; }
        [MaxLength(5000)]
        public string JobOpeningDescription { get; set; }
        [MaxLength(5000)]
        public string JobOpeningNotes { get; set; }

        //Company
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
        [MaxLength(5000)]
        public string CompanyNotes { get; set; }

    }
}
