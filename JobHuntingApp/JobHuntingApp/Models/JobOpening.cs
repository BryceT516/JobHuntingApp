using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class JobOpening
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string Title { get; set; }
        public DateTime Recorded { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        public bool Active { get; set; }
    }
}
