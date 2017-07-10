using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class Idea
    {
        public int IdeaID { get; set; }
        public int CompanyID { get; set; }
        [MaxLength(5000)]
        public string IdeaNote { get; set; }
        public DateTime IdeaCreated { get; set; }
        public DateTime IdeaModified { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
    }
}
