using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class adjusted_potentialmatchmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f12396b6-5df8-4a64-906a-bab0a3d22613");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PotentialMatches");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "PotentialMatches",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "PotentialMatches",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cuisines",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceRange",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "654642f3-7999-4cfe-af61-48583f1ce607", "a80f719f-18fc-4054-a21f-6e9ad306043d", "Diner", "DINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "654642f3-7999-4cfe-af61-48583f1ce607");

            migrationBuilder.DropColumn(
                name: "Cuisines",
                table: "PotentialMatches");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PotentialMatches");

            migrationBuilder.DropColumn(
                name: "PriceRange",
                table: "PotentialMatches");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "PotentialMatches",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "PotentialMatches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "PotentialMatches",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f12396b6-5df8-4a64-906a-bab0a3d22613", "55230320-63dc-4d20-9a68-57510130a101", "Diner", "DINER" });
        }
    }
}
