﻿using System;
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

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<JobOpening> JobOpenings { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<ContactRecord> ContactRecords { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
                    
    }
    
}
