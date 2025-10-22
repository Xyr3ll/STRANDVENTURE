using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackDescriptionToStudentAssessmentResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeedbackDescription",
                table: "StudentAssessmentResults",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 55, 40, 770, DateTimeKind.Utc).AddTicks(8954), "PBKDF2-HMACSHA256.210000.LKags9Jf0jAZx/dbTgpoWw==.dya/EAubltKePOP7GHJV9f/cDK2+y4/20jeRNNAEg9k=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 55, 40, 639, DateTimeKind.Utc).AddTicks(8543), "PBKDF2-HMACSHA256.210000.lGWDNdN2sCe5OirozHwUwA==.FPw9jAHi94B5kAconW4aNg9NZrpjqrRAtaLzDqDSJjs=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackDescription",
                table: "StudentAssessmentResults");

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
        }
    }
}
