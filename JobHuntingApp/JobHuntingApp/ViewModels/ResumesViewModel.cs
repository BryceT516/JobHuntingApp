using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace JobHuntingApp.ViewModels
{
    public class ResumesViewModel
    {
        public int ResumeID { get; set; }
        public string ResumeTitle { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
        public string ContentType { get; set; }
        public string ResumeFileName { get; set; }
        [Required(ErrorMessage = "Please Upload a Valid File")]
        [Display(Name = "Upload Resume File")]        
        public IFormFile ResumeFile { get; set; }

    }
}
