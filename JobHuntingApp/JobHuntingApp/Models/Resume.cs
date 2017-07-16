﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobHuntingApp.Models
{
    public class Resume
    {
        public int ResumeID { get; set; }
        public string ResumeTitle { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
        public string ContentType { get; set; }
        public string ResumeFile { get; set; }
    }
}
