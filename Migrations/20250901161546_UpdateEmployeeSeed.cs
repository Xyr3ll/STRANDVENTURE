using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "LastLoginAt", "Name", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), new DateTime(2025, 9, 2, 0, 15, 46, 88, DateTimeKind.Local).AddTicks(2194), "teacher1@gmail.com", true, null, "Teacher 1", "PBKDF2-HMACSHA256.210000.PNXSS6xiYYFJYlbhN49ozw==.V8AzyE5+esNy5BWxuBuih8Zyql0g5x5pDhhsGRjcSqM=", "Teacher" },
                    { new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"), new DateTime(2025, 9, 2, 0, 15, 46, 62, DateTimeKind.Local).AddTicks(8479), "superadmin@gmail.com", true, null, "Super", "PBKDF2-HMACSHA256.210000.cN1lErw/DSXXiC2Ia6s/2g==.vDtDftrm0nDgAhNkYVBSJs4kuClVvV0kJxnPZob/01k=", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Strands",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0afc1ab3-4cea-42d6-b759-bf44b829fad4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Science, Technology, Engineering, Mathematics", true, "STEM" },
                    { new Guid("1fb5c2a0-650f-443c-bd45-6e7adbaee4c7"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "General Academic Strand", true, "GAS" },
                    { new Guid("26756dc7-ba72-49a3-bc14-a7d7053031a9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Arts and Design Track", true, "ARTS & DESIGN" },
                    { new Guid("2e39c993-3ebf-4e46-843f-41c80065f894"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sports Track", true, "SPORTS" },
                    { new Guid("51a0f2ea-61d9-4e8f-b852-884dac783063"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Humanities and Social Sciences", true, "HUMSS" },
                    { new Guid("c5dd0fa9-ea6b-4adf-9820-0349244c7f6d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Accountancy, Business and Management", true, "ABM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("0afc1ab3-4cea-42d6-b759-bf44b829fad4"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("1fb5c2a0-650f-443c-bd45-6e7adbaee4c7"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("26756dc7-ba72-49a3-bc14-a7d7053031a9"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("2e39c993-3ebf-4e46-843f-41c80065f894"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("51a0f2ea-61d9-4e8f-b852-884dac783063"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("c5dd0fa9-ea6b-4adf-9820-0349244c7f6d"));

            migrationBuilder.InsertData(
                table: "Strands",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Science, Technology, Engineering, Mathematics", true, "STEM" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Humanities and Social Sciences", true, "HUMSS" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Accountancy, Business and Management", true, "ABM" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "General Academic Strand", true, "GAS" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sports Track", true, "SPORTS" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Arts and Design Track", true, "ARTS & DESIGN" }
                });
        }
    }
}
