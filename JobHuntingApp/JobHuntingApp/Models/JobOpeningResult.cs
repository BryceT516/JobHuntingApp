using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class JobOpeningResult
    {
        public int JobOpeningResultID { get; set; }
        public int JobID { get; set; }
        public DateTime JobOpeningResultCreated { get; set; }
        public string JobOpeningResultNote { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
    }
}
