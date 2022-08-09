using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDKHostAPI.Migrations
{
    public partial class TestDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BloodTypes",
                columns: new[] { "Id", "Name", "PhFactor" },
                values: new object[,]
                {
                    { 1, "A", "+" },
                    { 2, "A", "-" },
                    { 3, "B", "+" },
                    { 4, "B", "-" },
                    { 5, "AB", "+" },
                    { 6, "AB", "-" },
                    { 7, "0", "+" },
                    { 8, "0", "-" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Škola u Donjem Crnjelovu", "Donje Crnjelovo" },
                    { 2, "Dom omladine", "Magnojević" },
                    { 3, "OŠ Knez Ivo od Semberije", "Bijeljina - Dašnjica 1" }
                });

            migrationBuilder.InsertData(
                table: "DonationEvents",
                columns: new[] { "Id", "Description", "EventDate", "LocationId" },
                values: new object[,]
                {
                    { 1, "Akcija dobrovoljnog darovanja krvi u D. Crnjelovu 2021", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, "Akcija dobrovoljnog darovanja krvi u Magnojevicu 2022", new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Donators",
                columns: new[] { "ID", "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Dusana Baranina 1/C/10, Bijeljina", new DateTime(1986, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "aleksbn417@gmail.com", "Aleksandar", "Matic", "065/417-302" },
                    { 2, "Vrulja bb, Donje Crnjelovo", new DateTime(1958, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "pperic@gmail.com", "Petar", "Peric", "065/257-417" },
                    { 3, "Gavrila Principa 14/22, Bijeljina", new DateTime(2000, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "ivanas@gmail.com", "Ivana", "Stevic", "065/741-956" },
                    { 4, "Mala Obarska BB", new DateTime(2001, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "majag@gmail.com", "Maja", "Gobeljic", "065/778-332" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 1 },
                    { 3, 2, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
