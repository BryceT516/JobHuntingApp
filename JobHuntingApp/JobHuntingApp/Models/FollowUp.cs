using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class FollowUp
    {
        public int FollowUpID { get; set; }
        public int JobID { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
        public ContactType FollowUpMethod { get; set; }
        public string FollowUpNotes { get; set; }
        public DateTime FollowUpOccured { get; set; }
    }
}
