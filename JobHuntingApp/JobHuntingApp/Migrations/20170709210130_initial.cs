using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobHuntingApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationMethod = table.Column<int>(nullable: false),
                    ApplicationSubmitted = table.Column<DateTime>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyActive = table.Column<bool>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyNotes = table.Column<string>(maxLength: 5000, nullable: true),
                    CompanyUrl = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "ContactRecords",
                columns: table => new
                {
                    ContactRecordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    ContactRecordAdded = table.Column<DateTime>(nullable: false),
                    ContactRecordNotes = table.Column<string>(maxLength: 5000, nullable: true),
                    ContactRecordOccured = table.Column<DateTime>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRecords", x => x.ContactRecordID);
                });

            migrationBuilder.CreateTable(
                name: "CoverLetters",
                columns: table => new
                {
                    CoverLetterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverLetterText = table.Column<string>(maxLength: 5000, nullable: true),
                    JobID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverLetters", x => x.CoverLetterID);
                });

            migrationBuilder.CreateTable(
                name: "HistoryItems",
                columns: table => new
                {
                    HistoryItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    HistoryItemCreated = table.Column<DateTime>(nullable: false),
                    HistoryItemDate = table.Column<DateTime>(nullable: false),
                    HistoryItemEvent = table.Column<string>(nullable: true),
                    HistoryItemText = table.Column<string>(nullable: true),
                    JobID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryItems", x => x.HistoryItemID);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    IdeaCreated = table.Column<DateTime>(nullable: false),
                    IdeaModified = table.Column<DateTime>(nullable: false),
                    IdeaNote = table.Column<string>(maxLength: 5000, nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaID);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CallBack = table.Column<bool>(nullable: false),
                    FollowUp = table.Column<bool>(nullable: false),
                    InterviewNotes = table.Column<string>(maxLength: 5000, nullable: true),
                    JobID = table.Column<int>(nullable: false),
                    Occurance = table.Column<DateTime>(nullable: false),
                    ThankYouEmail = table.Column<bool>(nullable: false),
                    ThankYouNote = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewID);
                });

            migrationBuilder.CreateTable(
                name: "JobOpenings",
                columns: table => new
                {
                    JobOpeningID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    JobOpeningActive = table.Column<bool>(nullable: false),
                    JobOpeningDescription = table.Column<string>(maxLength: 5000, nullable: true),
                    JobOpeningNotes = table.Column<string>(maxLength: 5000, nullable: true),
                    JobOpeningRecorded = table.Column<DateTime>(nullable: false),
                    JobOpeningSource = table.Column<string>(nullable: true),
                    JobOpeningTitle = table.Column<string>(nullable: true),
                    JobOpeningUrl = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOpenings", x => x.JobOpeningID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 5000, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskCompleted = table.Column<DateTime>(nullable: false),
                    TaskCreated = table.Column<DateTime>(nullable: false),
                    TaskNotes = table.Column<string>(maxLength: 5000, nullable: true),
                    TaskText = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ContactRecords");

            migrationBuilder.DropTable(
                name: "CoverLetters");

            migrationBuilder.DropTable(
                name: "HistoryItems");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "JobOpenings");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
