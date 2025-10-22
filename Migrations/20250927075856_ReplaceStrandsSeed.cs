using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceStrandsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 27, 7, 58, 56, 371, DateTimeKind.Utc).AddTicks(3657), "PBKDF2-HMACSHA256.210000.V0Ca/etW4qkoEk33nB+53w==.fPg5iCMVRdqXFoHOvY5OMtU6ZA8a6Ej3l7Mrc5pmZzQ=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 27, 7, 58, 56, 345, DateTimeKind.Utc).AddTicks(1529), "PBKDF2-HMACSHA256.210000.L1QaL9bJ8ZsOmAzCzwNz6w==.WQlXdFZsEi5mhIh7TwoBvQ969wyl/RGMdD2maCt+Mig=" });

            migrationBuilder.InsertData(
                table: "Strands",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-4789-9a8b-cd1e2f3a4b22"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "STEM pathway focusing on physics, advanced math, design thinking, prototyping and applied engineering concepts.", true, "STEM–Eng" },
                    { new Guid("2d4f6b7c-8e5a-4c3d-9f2e-7a6b5c4d3e77"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Humanities & Social Sciences track variant highlighting communication, culture, social inquiry and community engagement.", true, "HUMSS–VG" },
                    { new Guid("4a3b2c1d-5e6f-4789-8a9b-bc1d2e3f4a11"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "STEM pathway emphasizing biology, chemistry, health sciences, research skills and preparation for medical fields.", true, "STEM–Med" },
                    { new Guid("5c3f9e2d-2c4d-4e6c-9d3a-2b4e7f8a6c55"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Visual communication: layout, branding, digital illustration, imaging basics and introductory UI/UX concepts.", true, "Graphics" },
                    { new Guid("6f5b7c7c-6d5e-4a4e-9b7a-0b7e4d6a9c11"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Focuses on travel, hospitality operations, destination management, customer service and sustainable tourism basics.", true, "Tourism" },
                    { new Guid("7b8c9d1e-2f3a-4b5c-8d9e-a1b2c3d4e5f6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Programming fundamentals, algorithms, databases, version control and application development lifecycle projects.", true, "Software Dev" },
                    { new Guid("9e8d7c6b-5a4f-4d3c-8b2a-1f6e5d4c3b99"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Food preparation, kitchen operations, baking, nutrition, sanitation, menu planning and basic culinary entrepreneurship.", true, "Culinary" },
                    { new Guid("cab2e5d5-53e8-4f5e-bc1d-6d4a9f8b7e33"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Accountancy, Business & Management: accounting fundamentals, entrepreneurship, finance, marketing and business planning.", true, "ABM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-4789-9a8b-cd1e2f3a4b22"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("2d4f6b7c-8e5a-4c3d-9f2e-7a6b5c4d3e77"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("4a3b2c1d-5e6f-4789-8a9b-bc1d2e3f4a11"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("5c3f9e2d-2c4d-4e6c-9d3a-2b4e7f8a6c55"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("6f5b7c7c-6d5e-4a4e-9b7a-0b7e4d6a9c11"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("7b8c9d1e-2f3a-4b5c-8d9e-a1b2c3d4e5f6"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("9e8d7c6b-5a4f-4d3c-8b2a-1f6e5d4c3b99"));

            migrationBuilder.DeleteData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("cab2e5d5-53e8-4f5e-bc1d-6d4a9f8b7e33"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 20, 6, 10, 59, 609, DateTimeKind.Utc).AddTicks(4845), "PBKDF2-HMACSHA256.210000.7aGzD5NivYTYGu+p1HBS9A==.26R9hb+aQmk7DmMRpLqw6J/5KXl30usU4hHlu5gyxhA=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 20, 6, 10, 59, 584, DateTimeKind.Utc).AddTicks(8257), "PBKDF2-HMACSHA256.210000.xoXuK7Pp/A7XWx2TCytdPQ==.fSMbcNx2UsMs0hKb8T63GtQSTsDbe6p9PH1xF/9wz88=" });

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
    }
}
