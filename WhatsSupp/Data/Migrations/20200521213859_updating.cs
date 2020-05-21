using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20e8836-ffe4-4a5b-a3db-ee0bd6f97cf5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e09fc28c-b0eb-4806-95e3-dca5550562b9", "aa874223-f066-4ac0-b556-9614fd8d0ec4", "Diner", "DINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e09fc28c-b0eb-4806-95e3-dca5550562b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f20e8836-ffe4-4a5b-a3db-ee0bd6f97cf5", "51e9c47e-6831-443d-912a-d8151ad60c24", "Diner", "DINER" });
        }
    }
}
