using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class seeded_cuisines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e4b0cd-ca3d-4d2c-8693-e58b9438e33d");

            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "Cuisines",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9be417b6-c8e3-422e-8fde-00514ac99221", "9dae2c3e-21aa-4dd6-a38d-746183cad6d3", "Diner", "DINER" });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "CuisineId", "CuisineName", "Selected" },
                values: new object[,]
                {
                    { 1, "Mexican", null },
                    { 2, "American", null },
                    { 3, "Italian", null },
                    { 4, "Chinese", null },
                    { 5, "Japanese", null },
                    { 6, "French", null },
                    { 7, "Burgers", null },
                    { 8, "Pizza", null },
                    { 9, "Bar Food", null },
                    { 10, "Indian", null },
                    { 11, "Fast Food", null },
                    { 12, "Thai", null },
                    { 13, "Vietnamese", null },
                    { 14, "Breakfast", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9be417b6-c8e3-422e-8fde-00514ac99221");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "CuisineId",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "Selected",
                table: "Cuisines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3e4b0cd-ca3d-4d2c-8693-e58b9438e33d", "8330e17d-0b0f-410b-8d9e-f2d47965cbe5", "Diner", "DINER" });
        }
    }
}
