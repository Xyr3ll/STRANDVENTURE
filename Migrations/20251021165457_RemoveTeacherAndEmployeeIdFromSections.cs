using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTeacherAndEmployeeIdFromSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Employees_TeacherId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_TeacherId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Sections");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Sections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 21, 16, 54, 53, 727, DateTimeKind.Utc).AddTicks(4296), "PBKDF2-HMACSHA256.210000.RsShKqKvwePq0mtuXZR+/A==.E3/0NEz6svGFQT37F6z8mQMXu7eDw+ynHAQYvTRY0WA=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 21, 16, 54, 53, 596, DateTimeKind.Utc).AddTicks(1742), "PBKDF2-HMACSHA256.210000.Ahljp3E3IhNvtJk1t570UA==.hwfkWZh1AYN7umoA9DJ7YShXQuG2+ZPWiV7Jl0Uk8GA=" });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_EmployeeId",
                table: "Sections",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Employees_EmployeeId",
                table: "Sections",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Employees_EmployeeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_EmployeeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Sections");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Sections",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 5, 9, 25, 735, DateTimeKind.Utc).AddTicks(1970), "PBKDF2-HMACSHA256.210000.Y5xc3lOUOU+CwBsPMQsUVQ==.hVm1fhu2DUU4j75oq8/6/It3AtLNEYAS2YiQFGpSFc0=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 5, 9, 25, 710, DateTimeKind.Utc).AddTicks(6903), "PBKDF2-HMACSHA256.210000.e8q3zI1ZMZKnazyQIVQ6ZA==.9gECyRkpWVBrhuIzIQ2ANsVn37bFRwff9G1gccYUAnM=" });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TeacherId",
                table: "Sections",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Employees_TeacherId",
                table: "Sections",
                column: "TeacherId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
