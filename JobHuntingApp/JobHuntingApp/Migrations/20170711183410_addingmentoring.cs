using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobHuntingApp.Migrations
{
    public partial class addingmentoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobOpenings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeID",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobOpeningResults",
                columns: table => new
                {
                    JobOpeningResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobID = table.Column<int>(nullable: false),
                    JobOpeningResultCreated = table.Column<DateTime>(nullable: false),
                    JobOpeningResultNote = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOpeningResults", x => x.JobOpeningResultID);
                });

            migrationBuilder.CreateTable(
                name: "Mentorships",
                columns: table => new
                {
                    MentorshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenteeID = table.Column<string>(maxLength: 450, nullable: true),
                    MentorID = table.Column<string>(maxLength: 450, nullable: true),
                    MentorshipEnd = table.Column<DateTime>(nullable: false),
                    MentorshipStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorships", x => x.MentorshipID);
                });

            migrationBuilder.CreateTable(
                name: "MentorshipNotes",
                columns: table => new
                {
                    MentorshipNoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    CoverLetterID = table.Column<int>(nullable: false),
                    InterviewID = table.Column<int>(nullable: false),
                    JobOpeningID = table.Column<int>(nullable: false),
                    MenteeID = table.Column<string>(maxLength: 450, nullable: true),
                    MentorID = table.Column<string>(maxLength: 450, nullable: true),
                    MentorshipNoteText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorshipNotes", x => x.MentorshipNoteID);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    ResumeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeFile = table.Column<byte>(nullable: false),
                    ResumeTitle = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ResumeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOpeningResults");

            migrationBuilder.DropTable(
                name: "Mentorships");

            migrationBuilder.DropTable(
                name: "MentorshipNotes");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobOpenings");

            migrationBuilder.DropColumn(
                name: "ResumeID",
                table: "Applications");

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
        }
    }
}
