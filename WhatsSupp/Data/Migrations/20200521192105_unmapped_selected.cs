using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class unmapped_selected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9be417b6-c8e3-422e-8fde-00514ac99221");

            migrationBuilder.DropColumn(
                name: "Selected",
                table: "Cuisines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f20e8836-ffe4-4a5b-a3db-ee0bd6f97cf5", "51e9c47e-6831-443d-912a-d8151ad60c24", "Diner", "DINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20e8836-ffe4-4a5b-a3db-ee0bd6f97cf5");

            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "Cuisines",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9be417b6-c8e3-422e-8fde-00514ac99221", "9dae2c3e-21aa-4dd6-a38d-746183cad6d3", "Diner", "DINER" });
        }
    }
}
