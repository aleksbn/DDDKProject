using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDKHostAPI.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53007191-e5ce-4260-8232-1b437cfbca86", "335bd86a-532a-4660-88c9-047907ccd273", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b35da6de-94a4-4a7d-95fe-6f7b32293e2d", "65ccb399-7c4f-4fce-83c8-33d5337aeaf1", "Mod", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53007191-e5ce-4260-8232-1b437cfbca86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b35da6de-94a4-4a7d-95fe-6f7b32293e2d");
        }
    }
}
