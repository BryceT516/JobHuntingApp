using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class Interview
    {
        public int InterviewID { get; set; }
        public int JobID { get; set; }
        public DateTime Occurance { get; set; }
        [MaxLength(5000)]
        public string InterviewNotes { get; set; }
        public bool ThankYouEmail { get; set; }
        public bool ThankYouNote { get; set; }
        public bool FollowUp { get; set; }
        public bool CallBack { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
    }
}
