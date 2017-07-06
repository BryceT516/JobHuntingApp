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
    partial class JobHuntContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobHuntingApp.Models.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationMethod");

                    b.Property<int>("JobID");

                    b.Property<DateTime>("Submitted");

                    b.HasKey("ID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobHuntingApp.Models.JobOpening", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("CompanyID");

                    b.Property<string>("Description");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("Recorded");

                    b.Property<string>("Source");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.ToTable("JobOpenings");
                });

            modelBuilder.Entity("JobHuntingApp.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("People");
                });
        }
    }
}
