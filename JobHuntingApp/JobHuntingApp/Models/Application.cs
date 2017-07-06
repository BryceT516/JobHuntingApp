using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntingApp.Models
{
    public enum ApplicationMethod{
        Online,
        Email,
        Mail,
        Fax
    }

    public class Application
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public DateTime Submitted { get; set; }
        public ApplicationMethod ApplicationMethod { get; set; }
    }
}
