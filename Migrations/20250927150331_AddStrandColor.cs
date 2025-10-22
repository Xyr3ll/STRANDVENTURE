using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddStrandColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Strands",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "#000000");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 27, 15, 3, 31, 507, DateTimeKind.Utc).AddTicks(5104), "PBKDF2-HMACSHA256.210000.UsPlpr3ikYsDTskb9kn8xw==.hSRRRWQu3qPLxcGWxfkMemCUiZuLseGNziaVhgdcTdQ=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 27, 15, 3, 31, 482, DateTimeKind.Utc).AddTicks(9392), "PBKDF2-HMACSHA256.210000.lQQDzBgWlGQZ5JH5QJ3fmA==.EgGFBlagKBRnFKM7C9RexiWdbBZfLGvzrWzHRh7gBHQ=" });

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-4789-9a8b-cd1e2f3a4b22"),
                column: "Color",
                value: "#2196f3");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("2d4f6b7c-8e5a-4c3d-9f2e-7a6b5c4d3e77"),
                column: "Color",
                value: "#009688");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("4a3b2c1d-5e6f-4789-8a9b-bc1d2e3f4a11"),
                column: "Color",
                value: "#e91e63");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("5c3f9e2d-2c4d-4e6c-9d3a-2b4e7f8a6c55"),
                column: "Color",
                value: "#9c27b0");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("6f5b7c7c-6d5e-4a4e-9b7a-0b7e4d6a9c11"),
                column: "Color",
                value: "#ff9800");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("7b8c9d1e-2f3a-4b5c-8d9e-a1b2c3d4e5f6"),
                column: "Color",
                value: "#607d8b");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("9e8d7c6b-5a4f-4d3c-8b2a-1f6e5d4c3b99"),
                column: "Color",
                value: "#795548");

            migrationBuilder.UpdateData(
                table: "Strands",
                keyColumn: "Id",
                keyValue: new Guid("cab2e5d5-53e8-4f5e-bc1d-6d4a9f8b7e33"),
                column: "Color",
                value: "#3f51b5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Strands");

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
        }
    }
}
