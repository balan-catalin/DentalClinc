using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsDentalClinic.Data.Migrations
{
    public partial class UpdatePatientService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MomentOfChoice",
                table: "PatientService",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PriceAtSelection",
                table: "PatientService",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MomentOfChoice",
                table: "PatientService");

            migrationBuilder.DropColumn(
                name: "PriceAtSelection",
                table: "PatientService");
        }
    }
}
