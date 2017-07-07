using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class TaskRecord
    {
        [Key]
        public int TaskID { get; set; }
        public DateTime TaskCreated { get; set; }
        public string TaskText { get; set; }
        public DateTime TaskCompleted { get; set; }
        [MaxLength(5000)]
        public string TaskNotes { get; set; }
    }
}
