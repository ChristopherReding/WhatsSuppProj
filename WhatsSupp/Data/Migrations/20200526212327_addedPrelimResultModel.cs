using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsSupp.Data.Migrations
{
    public partial class addedPrelimResultModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e09fc28c-b0eb-4806-95e3-dca5550562b9");

            migrationBuilder.DropColumn(
                name: "GooglePlaceId",
                table: "PotentialMatches");

            migrationBuilder.DropColumn(
                name: "GoogleRating",
                table: "PotentialMatches");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "PotentialMatches",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f12396b6-5df8-4a64-906a-bab0a3d22613", "55230320-63dc-4d20-9a68-57510130a101", "Diner", "DINER" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Diner1Id",
                table: "Contacts",
                column: "Diner1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Diner2Id",
                table: "Contacts",
                column: "Diner2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Diners_Diner1Id",
                table: "Contacts",
                column: "Diner1Id",
                principalTable: "Diners",
                principalColumn: "DinerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Diners_Diner2Id",
                table: "Contacts",
                column: "Diner2Id",
                principalTable: "Diners",
                principalColumn: "DinerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Diners_Diner1Id",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Diners_Diner2Id",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Diner1Id",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Diner2Id",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f12396b6-5df8-4a64-906a-bab0a3d22613");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PotentialMatches");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "PotentialMatches");

            migrationBuilder.AddColumn<string>(
                name: "GooglePlaceId",
                table: "PotentialMatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoogleRating",
                table: "PotentialMatches",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e09fc28c-b0eb-4806-95e3-dca5550562b9", "aa874223-f066-4ac0-b556-9614fd8d0ec4", "Diner", "DINER" });
        }
    }
}
