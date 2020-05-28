using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class added_boolapproved_to_potentialmatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "654642f3-7999-4cfe-af61-48583f1ce607");

            migrationBuilder.AddColumn<bool>(
                name: "Diner1Approved",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Diner2Approved",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3b632de-6d94-4dd5-a3ad-47774655d8fc", "83ce7926-998f-471a-b4d8-111f4e2b48f8", "Diner", "DINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3b632de-6d94-4dd5-a3ad-47774655d8fc");

            migrationBuilder.DropColumn(
                name: "Diner1Approved",
                table: "PotentialMatches");

            migrationBuilder.DropColumn(
                name: "Diner2Approved",
                table: "PotentialMatches");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "654642f3-7999-4cfe-af61-48583f1ce607", "a80f719f-18fc-4054-a21f-6e9ad306043d", "Diner", "DINER" });
        }
    }
}
