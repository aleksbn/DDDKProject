using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDKHostAPI.Migrations
{
    public partial class PreviousDonationsAddes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousDonations",
                table: "Donators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 1,
                column: "PreviousDonations",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 2,
                column: "PreviousDonations",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 3,
                column: "PreviousDonations",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 4,
                column: "PreviousDonations",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousDonations",
                table: "Donators");
        }
    }
}
