using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class CoverLetter
    {
        public int CoverLetterID { get; set; }
        public int JobID { get; set; }
        [MaxLength(5000)]
        public string CoverLetterText { get; set; }
    }
}
