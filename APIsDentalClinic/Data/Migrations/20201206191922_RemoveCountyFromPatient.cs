using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsDentalClinic.Data.Migrations
{
    public partial class RemoveCountyFromPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_County_CountyId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_CountyId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_CountyId",
                table: "Patient",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_County_CountyId",
                table: "Patient",
                column: "CountyId",
                principalTable: "County",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
