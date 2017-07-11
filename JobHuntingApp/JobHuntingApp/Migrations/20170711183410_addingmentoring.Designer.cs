using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

namespace JobHuntingApp.Migrations
{
    [DbContext(typeof(JobHuntContext))]
    [Migration("20170711183410_addingmentoring")]
    partial class addingmentoring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobHuntingApp.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationMethod");

                    b.Property<DateTime>("ApplicationSubmitted");

                    b.Property<int>("JobID");

                    b.Property<int>("ResumeID");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("ApplicationID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CompanyActive");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyNotes")
                        .HasMaxLength(5000);

                    b.Property<string>("CompanyUrl");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobHuntingApp.Models.ContactRecord", b =>
                {
                    b.Property<int>("ContactRecordID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<DateTime>("ContactRecordAdded");

                    b.Property<string>("ContactRecordNotes")
                        .HasMaxLength(5000);

                    b.Property<DateTime>("ContactRecordOccured");

                    b.Property<int>("ContactType");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("ContactRecordID");

                    b.ToTable("ContactRecords");
                });

            modelBuilder.Entity("JobHuntingApp.Models.CoverLetter", b =>
                {
                    b.Property<int>("CoverLetterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverLetterText")
                        .HasMaxLength(5000);

                    b.Property<int>("JobID");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("CoverLetterID");

                    b.ToTable("CoverLetters");
                });

            modelBuilder.Entity("JobHuntingApp.Models.HistoryItem", b =>
                {
                    b.Property<int>("HistoryItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<DateTime>("HistoryItemCreated");

                    b.Property<DateTime>("HistoryItemDate");

                    b.Property<string>("HistoryItemEvent");

                    b.Property<string>("HistoryItemText");

                    b.Property<int>("JobID");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("HistoryItemID");

                    b.ToTable("HistoryItems");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Interview", b =>
                {
                    b.Property<int>("InterviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CallBack");

                    b.Property<bool>("FollowUp");

                    b.Property<string>("InterviewNotes")
                        .HasMaxLength(5000);

                    b.Property<int>("JobID");

                    b.Property<DateTime>("Occurance");

                    b.Property<bool>("ThankYouEmail");

                    b.Property<bool>("ThankYouNote");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("InterviewID");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("JobHuntingApp.Models.JobOpening", b =>
                {
                    b.Property<int>("JobOpeningID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<bool>("JobOpeningActive");

                    b.Property<string>("JobOpeningDescription")
                        .HasMaxLength(8000);

                    b.Property<string>("JobOpeningNotes")
                        .HasMaxLength(5000);

                    b.Property<DateTime>("JobOpeningRecorded");

                    b.Property<string>("JobOpeningSource")
                        .HasMaxLength(200);

                    b.Property<string>("JobOpeningTitle")
                        .HasMaxLength(200);

                    b.Property<string>("JobOpeningUrl")
                        .HasMaxLength(200);

                    b.Property<string>("Location")
                        .HasMaxLength(200);

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("JobOpeningID");

                    b.ToTable("JobOpenings");
                });

            modelBuilder.Entity("JobHuntingApp.Models.JobOpeningResult", b =>
                {
                    b.Property<int>("JobOpeningResultID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("JobID");

                    b.Property<DateTime>("JobOpeningResultCreated");

                    b.Property<string>("JobOpeningResultNote");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("JobOpeningResultID");

                    b.ToTable("JobOpeningResults");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Mentorship", b =>
                {
                    b.Property<int>("MentorshipID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MenteeID")
                        .HasMaxLength(450);

                    b.Property<string>("MentorID")
                        .HasMaxLength(450);

                    b.Property<DateTime>("MentorshipEnd");

                    b.Property<DateTime>("MentorshipStart");

                    b.HasKey("MentorshipID");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("JobHuntingApp.Models.MentorshipNote", b =>
                {
                    b.Property<int>("MentorshipNoteID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<int>("CoverLetterID");

                    b.Property<int>("InterviewID");

                    b.Property<int>("JobOpeningID");

                    b.Property<string>("MenteeID")
                        .HasMaxLength(450);

                    b.Property<string>("MentorID")
                        .HasMaxLength(450);

                    b.Property<string>("MentorshipNoteText");

                    b.HasKey("MentorshipNoteID");

                    b.ToTable("MentorshipNotes");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("Notes")
                        .HasMaxLength(5000);

                    b.Property<string>("Phone");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("PersonID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Resume", b =>
                {
                    b.Property<int>("ResumeID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("ResumeFile");

                    b.Property<string>("ResumeTitle");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("ResumeID");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobHuntingApp.Models.TaskRecord", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("TaskCompleted");

                    b.Property<DateTime>("TaskCreated");

                    b.Property<string>("TaskNotes")
                        .HasMaxLength(5000);

                    b.Property<string>("TaskText");

                    b.Property<string>("UserID")
                        .HasMaxLength(450);

                    b.HasKey("TaskID");

                    b.ToTable("Tasks");
                });
        }
    }
}
