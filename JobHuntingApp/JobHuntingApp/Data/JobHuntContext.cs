using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Models;

namespace JobHuntingApp.Data
{
    public class JobHuntContext : DbContext
    {
        public JobHuntContext(DbContextOptions<JobHuntContext> options) : base(options)
        { }


        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactRecord> ContactRecords { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<JobOpening> JobOpenings { get; set; }
        public DbSet<JobOpeningResult> JobOpeningResults { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<MentorshipNote> MentorshipNotes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        
    }
    
}
