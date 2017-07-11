using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class MentorshipNote
    {
        public int MentorshipNoteID { get; set; }
        [StringLength(450)]
        public string MenteeID { get; set; }
        [StringLength(450)]
        public string MentorID { get; set; }
        public int JobOpeningID { get; set; }
        public int CoverLetterID { get; set; }
        public int CompanyID { get; set; }
        public int InterviewID { get; set; }
        public string MentorshipNoteText { get; set; }

    }
}
