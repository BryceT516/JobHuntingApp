using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public enum ContactType
    {
        Email,
        InPerson,
        Phone,
        Letter
    }


    public class ContactRecord
    {
        public int ContactRecordID { get; set; }
        public int CompanyID { get; set; }
        [MaxLength(5000)]
        public string ContactRecordNotes { get; set; }
        public DateTime ContactRecordAdded { get; set; }
        public DateTime ContactRecordOccured { get; set; }
        public ContactType ContactType { get; set; }
    }
}
