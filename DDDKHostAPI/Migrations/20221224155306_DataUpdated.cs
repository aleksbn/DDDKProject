using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDKHostAPI.Migrations
{
    public partial class DataUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53007191-e5ce-4260-8232-1b437cfbca86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b35da6de-94a4-4a7d-95fe-6f7b32293e2d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e950671-8968-413a-8c2c-4a025794a673", "819fa164-8357-4935-97c5-ad1192b3e149", "Mod", "MODERATOR" },
                    { "815b0251-1b6b-4a2c-ae26-996d7f69f9ee", "c4292a59-46f4-431b-9957-91ad89a2bb94", "Admin", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "DonationEvents",
                columns: new[] { "Id", "Description", "EventDate", "LocationId" },
                values: new object[,]
                {
                    { 3, "Akcija dobrovoljnog darovanja krvi br. 2", new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Akcija dobrovoljnog darovanja krvi br. 3", new DateTime(2018, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, "Akcija dobrovoljnog darovanja krvi br. 7", new DateTime(2015, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Akcija dobrovoljnog darovanja krvi br. 8", new DateTime(2017, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "Akcija dobrovoljnog darovanja krvi br. 12", new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, "Akcija dobrovoljnog darovanja krvi br. 13", new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, "Akcija dobrovoljnog darovanja krvi br. 18", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[] { 181, 2, 4 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Dusana Baranina 86", new DateTime(1987, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "DejanLalic1921000009@gmail.com", "Dejan", "Lalic", "065/421-839", 18 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Sime Matavulja 2", new DateTime(1950, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DejanIvkovic1407598415@gmail.com", "Dejan", "Ivkovic", "065/768-700", 10 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Kralja Petra I Karadjordjevica 30", new DateTime(1958, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "MitarBecic501237232@gmail.com", "Mitar", "Becic", "065/595-961", 10 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Address", "BirthDate", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Kralja Petra I Karadjordjevica 125", new DateTime(1976, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "JovanaStevanovic653417260@gmail.com", "Jovana", "Stevanovic", "065/113-650", 14 });

            migrationBuilder.InsertData(
                table: "Donators",
                columns: new[] { "ID", "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[,]
                {
                    { 5, "Svetozara Markovica 181", new DateTime(1981, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DejanTadic1596002669@gmail.com", "Dejan", "Tadic", "065/562-625", 19 },
                    { 6, "Danila Kisa 22", new DateTime(1999, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "IvanaTanaskovic166879211@gmail.com", "Ivana", "Tanaskovic", "065/740-342", 16 },
                    { 7, "Dusana Silnog 131", new DateTime(1993, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "IvanDjordjevic1822315695@gmail.com", "Ivan", "Djordjevic", "065/966-769", 7 },
                    { 8, "Dinastije Obrenovic 73", new DateTime(1964, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "NikolinaDjordjevic792331423@gmail.com", "Nikolina", "Djordjevic", "065/848-276", 18 },
                    { 9, "Dusana Silnog 78", new DateTime(1968, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "AleksandraStojkovic1326566077@gmail.com", "Aleksandra", "Stojkovic", "065/764-579", 11 },
                    { 10, "Dinastije Obrenovic 104", new DateTime(1970, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "NevenTanaskovic26767992@gmail.com", "Neven", "Tanaskovic", "065/425-133", 3 },
                    { 11, "Kralja Petra I Karadjordjevica 180", new DateTime(1953, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DejanLalic1185025398@gmail.com", "Dejan", "Lalic", "065/179-619", 16 },
                    { 12, "Patrijarha Pavla 57", new DateTime(1955, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NikolinaAleksic1211252397@gmail.com", "Nikolina", "Aleksic", "065/376-735", 17 },
                    { 13, "Jovana Ducica 27", new DateTime(1963, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ZeljkaStevic98602067@gmail.com", "Zeljka", "Stevic", "065/924-240", 11 },
                    { 14, "Mihajla Pupina 100", new DateTime(1989, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "IvanaLalic1284667572@gmail.com", "Ivana", "Lalic", "065/142-630", 14 },
                    { 15, "Dusana Silnog 58", new DateTime(1990, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MirkoBojic101560506@gmail.com", "Mirko", "Bojic", "065/390-193", 8 },
                    { 16, "Dusana Baranina 161", new DateTime(1995, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "MarijaTanaskovic1756391511@gmail.com", "Marija", "Tanaskovic", "065/525-340", 8 },
                    { 17, "Svetozara Markovica 112", new DateTime(1987, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NikolinaJokanovic1442604654@gmail.com", "Nikolina", "Jokanovic", "065/788-966", 6 },
                    { 18, "Mihajla Pupina 167", new DateTime(1994, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "AleksandarStojkovic487589247@gmail.com", "Aleksandar", "Stojkovic", "065/934-931", 12 },
                    { 19, "Svetozara Markovica 199", new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SandraPetrovic328810608@gmail.com", "Sandra", "Petrovic", "065/824-335", 15 },
                    { 20, "Dusana Baranina 12", new DateTime(1962, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MitarMarkovic1632380195@gmail.com", "Mitar", "Markovic", "065/205-414", 10 },
                    { 21, "Nikole Tesle 111", new DateTime(1979, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "MitarBecic1264220816@gmail.com", "Mitar", "Becic", "065/888-925", 2 },
                    { 22, "Dusana Baranina 183", new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "AleksandraPopovic355859244@gmail.com", "Aleksandra", "Popovic", "065/342-246", 14 },
                    { 23, "Ive Andrica 175", new DateTime(1999, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "IvanJokanovic947332160@gmail.com", "Ivan", "Jokanovic", "065/288-399", 19 },
                    { 24, "Nikole Tesle 199", new DateTime(1962, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BojanMarkovic1384154158@gmail.com", "Bojan", "Markovic", "065/516-744", 3 },
                    { 25, "Dusana Silnog 37", new DateTime(1971, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "MitarJovic816575905@gmail.com", "Mitar", "Jovic", "065/176-663", 18 },
                    { 26, "Petra Kocica 177", new DateTime(1968, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SlavkoStevic1111217866@gmail.com", "Slavko", "Stevic", "065/976-267", 14 },
                    { 27, "Svetog Save 37", new DateTime(1954, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "UrosIvkovic1553616651@gmail.com", "Uros", "Ivkovic", "065/318-439", 2 },
                    { 28, "Patrijarha Pavla 39", new DateTime(1953, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "IvanTanaskovic1882093608@gmail.com", "Ivan", "Tanaskovic", "065/463-366", 15 },
                    { 29, "Petra Kocica 193", new DateTime(1957, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "NevenaStevic1459169646@gmail.com", "Nevena", "Stevic", "065/962-550", 20 },
                    { 30, "Masarikova 85", new DateTime(1988, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "NevenIvkovic1058554250@gmail.com", "Neven", "Ivkovic", "065/887-739", 19 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "OŠ Vuk Karadžić", "Bijeljina - Vuk Karadzic skola" },
                    { 5, "OŠ Sveti Sava", "Dvorovi - škola" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "Dom Omladine Velika Obarska", "Velika Obarska" },
                    { 7, "Sala Osnovne škole", "Batković" },
                    { 8, "Ambulanta Branjevo", "Branjevo" },
                    { 9, "OŠ Jovan Dučić Patkovača", "Patkovača" },
                    { 10, "Banja Dvorovi", "Dvorovi - Banja" }
                });

            migrationBuilder.UpdateData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EventDate", "LocationId" },
                values: new object[] { "Akcija dobrovoljnog darovanja krvi br. 0", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "EventDate", "LocationId" },
                values: new object[] { "Akcija dobrovoljnog darovanja krvi br. 1", new DateTime(2016, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.InsertData(
                table: "DonationEvents",
                columns: new[] { "Id", "Description", "EventDate", "LocationId" },
                values: new object[,]
                {
                    { 5, "Akcija dobrovoljnog darovanja krvi br. 4", new DateTime(2018, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 6, "Akcija dobrovoljnog darovanja krvi br. 5", new DateTime(2015, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, "Akcija dobrovoljnog darovanja krvi br. 6", new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, "Akcija dobrovoljnog darovanja krvi br. 9", new DateTime(2015, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 11, "Akcija dobrovoljnog darovanja krvi br. 10", new DateTime(2017, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, "Akcija dobrovoljnog darovanja krvi br. 11", new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 15, "Akcija dobrovoljnog darovanja krvi br. 14", new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 16, "Akcija dobrovoljnog darovanja krvi br. 15", new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 17, "Akcija dobrovoljnog darovanja krvi br. 16", new DateTime(2017, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 18, "Akcija dobrovoljnog darovanja krvi br. 17", new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 20, "Akcija dobrovoljnog darovanja krvi br. 19", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 }
                });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 13, 11 });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 12, 9, 24 },
                    { 13, 2, 18 },
                    { 15, 13, 19 },
                    { 20, 13, 21 },
                    { 21, 14, 14 },
                    { 22, 1, 8 },
                    { 26, 8, 7 },
                    { 27, 1, 20 },
                    { 31, 9, 17 },
                    { 33, 3, 25 },
                    { 34, 9, 9 },
                    { 35, 3, 17 },
                    { 36, 13, 16 },
                    { 38, 19, 24 },
                    { 40, 1, 17 },
                    { 41, 3, 16 },
                    { 43, 1, 21 },
                    { 47, 9, 16 },
                    { 48, 2, 16 },
                    { 49, 4, 9 },
                    { 52, 4, 30 },
                    { 54, 8, 17 },
                    { 57, 1, 17 },
                    { 58, 1, 8 },
                    { 60, 19, 12 },
                    { 61, 2, 11 },
                    { 63, 3, 3 },
                    { 65, 14, 20 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 66, 19, 13 },
                    { 67, 4, 23 },
                    { 68, 2, 26 },
                    { 69, 8, 16 },
                    { 71, 9, 7 },
                    { 73, 8, 27 },
                    { 78, 3, 22 },
                    { 81, 4, 9 },
                    { 82, 8, 1 },
                    { 86, 3, 24 },
                    { 91, 3, 19 },
                    { 93, 4, 30 },
                    { 94, 1, 30 },
                    { 95, 4, 10 },
                    { 97, 19, 12 },
                    { 98, 14, 21 },
                    { 99, 3, 2 },
                    { 100, 2, 7 },
                    { 102, 2, 30 },
                    { 107, 14, 4 },
                    { 109, 4, 8 },
                    { 110, 1, 7 },
                    { 113, 9, 23 },
                    { 114, 2, 27 },
                    { 115, 8, 11 },
                    { 116, 4, 3 },
                    { 117, 3, 21 },
                    { 119, 3, 13 },
                    { 121, 4, 7 },
                    { 122, 19, 9 },
                    { 124, 4, 1 },
                    { 125, 2, 7 },
                    { 127, 9, 1 },
                    { 128, 3, 10 },
                    { 133, 2, 24 },
                    { 134, 19, 4 },
                    { 135, 1, 9 },
                    { 138, 19, 5 },
                    { 142, 3, 25 },
                    { 143, 14, 30 },
                    { 146, 14, 30 },
                    { 147, 13, 25 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 148, 14, 15 },
                    { 151, 1, 26 },
                    { 152, 19, 25 },
                    { 154, 19, 14 },
                    { 155, 19, 12 },
                    { 156, 14, 15 },
                    { 158, 2, 22 },
                    { 165, 1, 23 },
                    { 166, 14, 27 },
                    { 167, 1, 15 },
                    { 168, 2, 21 },
                    { 169, 9, 17 },
                    { 173, 4, 26 },
                    { 177, 8, 2 },
                    { 180, 1, 18 },
                    { 182, 19, 18 },
                    { 183, 8, 17 },
                    { 184, 3, 26 },
                    { 186, 14, 30 },
                    { 188, 9, 15 },
                    { 190, 8, 20 },
                    { 191, 1, 11 },
                    { 195, 14, 25 },
                    { 196, 19, 17 },
                    { 199, 9, 22 },
                    { 200, 9, 13 }
                });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 7, 4 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 20, 15 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 16, 30 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 6, 12 });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 6, 15, 26 },
                    { 7, 10, 9 },
                    { 8, 5, 25 },
                    { 9, 15, 5 },
                    { 10, 5, 7 },
                    { 11, 11, 23 },
                    { 14, 20, 10 },
                    { 16, 17, 13 },
                    { 17, 5, 2 },
                    { 18, 20, 7 },
                    { 19, 12, 3 },
                    { 23, 16, 15 },
                    { 24, 7, 21 },
                    { 25, 20, 22 },
                    { 28, 10, 3 },
                    { 29, 7, 28 },
                    { 30, 16, 10 },
                    { 32, 18, 4 },
                    { 37, 11, 2 },
                    { 39, 10, 29 },
                    { 42, 12, 17 },
                    { 44, 7, 23 },
                    { 45, 20, 30 },
                    { 46, 17, 4 },
                    { 50, 10, 6 },
                    { 51, 20, 16 },
                    { 53, 15, 6 },
                    { 55, 10, 28 },
                    { 56, 18, 5 },
                    { 59, 17, 29 },
                    { 62, 7, 13 },
                    { 64, 16, 8 },
                    { 70, 16, 26 },
                    { 72, 6, 1 },
                    { 74, 18, 25 },
                    { 75, 20, 3 },
                    { 76, 16, 23 },
                    { 77, 12, 11 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 79, 6, 15 },
                    { 80, 12, 3 },
                    { 83, 11, 4 },
                    { 84, 18, 21 },
                    { 85, 10, 15 },
                    { 87, 5, 6 },
                    { 88, 15, 10 },
                    { 89, 5, 17 },
                    { 90, 15, 15 },
                    { 92, 11, 21 },
                    { 96, 11, 27 },
                    { 101, 10, 19 },
                    { 103, 10, 25 },
                    { 104, 7, 8 },
                    { 105, 11, 27 },
                    { 106, 11, 22 },
                    { 108, 12, 22 },
                    { 111, 17, 8 },
                    { 112, 16, 15 },
                    { 118, 10, 25 },
                    { 120, 11, 16 },
                    { 123, 18, 9 },
                    { 126, 20, 23 },
                    { 129, 17, 28 },
                    { 130, 17, 11 },
                    { 131, 6, 1 },
                    { 132, 12, 3 },
                    { 136, 12, 12 },
                    { 137, 11, 13 },
                    { 139, 11, 6 },
                    { 140, 18, 23 },
                    { 141, 17, 14 },
                    { 144, 11, 3 },
                    { 145, 7, 6 },
                    { 149, 15, 5 },
                    { 150, 6, 2 },
                    { 153, 11, 10 },
                    { 157, 20, 18 },
                    { 159, 10, 1 },
                    { 160, 10, 16 },
                    { 161, 12, 19 },
                    { 162, 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DonationEventId", "DonatorId" },
                values: new object[,]
                {
                    { 163, 18, 5 },
                    { 164, 18, 26 },
                    { 170, 16, 26 },
                    { 171, 10, 19 },
                    { 172, 11, 20 },
                    { 174, 15, 10 },
                    { 175, 17, 4 },
                    { 176, 10, 3 },
                    { 178, 12, 13 },
                    { 179, 16, 23 },
                    { 185, 15, 20 },
                    { 187, 12, 28 },
                    { 189, 16, 11 },
                    { 192, 15, 7 },
                    { 193, 7, 3 },
                    { 194, 5, 19 },
                    { 197, 17, 19 },
                    { 198, 10, 29 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e950671-8968-413a-8c2c-4a025794a673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "815b0251-1b6b-4a2c-ae26-996d7f69f9ee");

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53007191-e5ce-4260-8232-1b437cfbca86", "335bd86a-532a-4660-88c9-047907ccd273", "Admin", "ADMINISTRATOR" },
                    { "b35da6de-94a4-4a7d-95fe-6f7b32293e2d", "65ccb399-7c4f-4fce-83c8-33d5337aeaf1", "Mod", "MODERATOR" }
                });

            migrationBuilder.UpdateData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EventDate", "LocationId" },
                values: new object[] { "Akcija dobrovoljnog darovanja krvi u D. Crnjelovu 2021", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "DonationEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "EventDate", "LocationId" },
                values: new object[] { "Akcija dobrovoljnog darovanja krvi u Magnojevicu 2022", new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DonationEventId", "DonatorId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Dusana Baranina 1/C/10, Bijeljina", new DateTime(1986, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "aleksbn417@gmail.com", "Aleksandar", "Matic", "065/417-302", 5 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Vrulja bb, Donje Crnjelovo", new DateTime(1958, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "pperic@gmail.com", "Petar", "Peric", "065/257-417", 89 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Address", "BirthDate", "BloodTypeId", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Gavrila Principa 14/22, Bijeljina", new DateTime(2000, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "ivanas@gmail.com", "Ivana", "Stevic", "065/741-956", 1 });

            migrationBuilder.UpdateData(
                table: "Donators",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Address", "BirthDate", "Email", "FirstName", "LastName", "PhoneNumber", "PreviousDonations" },
                values: new object[] { "Mala Obarska BB", new DateTime(2001, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "majag@gmail.com", "Maja", "Gobeljic", "065/778-332", 2 });
        }
    }
}
