using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class JobOpening
    {
        public int JobOpeningID { get; set; }
        public int CompanyID { get; set; }
        public string JobOpeningTitle { get; set; }
        public DateTime JobOpeningRecorded { get; set; }
        public string JobOpeningSource { get; set; }
        public string JobOpeningUrl { get; set; }
        [MaxLength(5000)]
        public string JobOpeningDescription { get; set; }
        [MaxLength(5000)]
        public string JobOpeningNotes { get; set; }
        public bool JobOpeningActive { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
    }
}
