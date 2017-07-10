using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class HistoryItem
    {
        public int HistoryItemID { get; set; }
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string HistoryItemEvent { get; set; }
        public string HistoryItemText { get; set; }
        public DateTime HistoryItemCreated { get; set; }
        public DateTime HistoryItemDate { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }

    }
}
