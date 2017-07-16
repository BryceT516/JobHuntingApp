using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobHuntingApp.Migrations
{
    public partial class resumes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResumeFile",
                table: "Resumes",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Resumes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Resumes");

            migrationBuilder.AlterColumn<byte>(
                name: "ResumeFile",
                table: "Resumes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
