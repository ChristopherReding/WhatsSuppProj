using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class created_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e3cb8a-45d8-4868-8659-504dfc0f1f98");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactJxnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diner1Id = table.Column<int>(nullable: true),
                    Diner2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactJxnId);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisineId);
                });

            migrationBuilder.CreateTable(
                name: "Diners",
                columns: table => new
                {
                    DinerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diners", x => x.DinerId);
                    table.ForeignKey(
                        name: "FK_Diners_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuisinePreferences",
                columns: table => new
                {
                    CuisineJxnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DinerId = table.Column<int>(nullable: true),
                    CuisineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisinePreferences", x => x.CuisineJxnId);
                    table.ForeignKey(
                        name: "FK_CuisinePreferences_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "CuisineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuisinePreferences_Diners_DinerId",
                        column: x => x.DinerId,
                        principalTable: "Diners",
                        principalColumn: "DinerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PotentialMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diner1Id = table.Column<int>(nullable: true),
                    Diner2Id = table.Column<int>(nullable: false),
                    RestaurantName = table.Column<string>(nullable: true),
                    GoogleRating = table.Column<int>(nullable: true),
                    RestaurantAddress = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: true),
                    GooglePlaceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialMatches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_PotentialMatches_Diners_Diner1Id",
                        column: x => x.Diner1Id,
                        principalTable: "Diners",
                        principalColumn: "DinerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PotentialMatches_Diners_Diner2Id",
                        column: x => x.Diner2Id,
                        principalTable: "Diners",
                        principalColumn: "DinerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3e4b0cd-ca3d-4d2c-8693-e58b9438e33d", "8330e17d-0b0f-410b-8d9e-f2d47965cbe5", "Diner", "DINER" });

            migrationBuilder.CreateIndex(
                name: "IX_CuisinePreferences_CuisineId",
                table: "CuisinePreferences",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_CuisinePreferences_DinerId",
                table: "CuisinePreferences",
                column: "DinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Diners_IdentityUserId",
                table: "Diners",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialMatches_Diner1Id",
                table: "PotentialMatches",
                column: "Diner1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialMatches_Diner2Id",
                table: "PotentialMatches",
                column: "Diner2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CuisinePreferences");

            migrationBuilder.DropTable(
                name: "PotentialMatches");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "Diners");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e4b0cd-ca3d-4d2c-8693-e58b9438e33d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7e3cb8a-45d8-4868-8659-504dfc0f1f98", "79cbc21b-8f4e-43cc-a5db-b4ea68ce9018", "Diner", "DINER" });
        }
    }
}
