using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        public bool Active { get; set; }
    }
}
