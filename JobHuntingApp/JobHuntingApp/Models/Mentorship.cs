using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace JobHuntingApp.Models
{
    public class Mentorship
    {
        public int MentorshipID { get; set; }
        [StringLength(450)]
        public string MentorID { get; set; }
        [StringLength(450)]
        public string MenteeID { get; set; }
        public DateTime MentorshipStart { get; set; }
        public DateTime MentorshipEnd { get; set; }
    }
}
