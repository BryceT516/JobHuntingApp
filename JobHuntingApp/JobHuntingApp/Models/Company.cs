using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
        [MaxLength(5000)]
        public string CompanyNotes { get; set; }
        public bool CompanyActive { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
    }
}
