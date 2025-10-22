using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class StudentNotifyAssessmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentNotifyAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotifyAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentNotifyAssessments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 28, 7, 8, 6, 574, DateTimeKind.Utc).AddTicks(2545), "PBKDF2-HMACSHA256.210000.HlEZhj5yS3eppkrngCIi6Q==.eaY8W3aSmiJvUhXdqklz57uEPL8+eo3KUhMBUq+hkpI=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 28, 7, 8, 6, 549, DateTimeKind.Utc).AddTicks(4113), "PBKDF2-HMACSHA256.210000.i6UdxWBYk6VVm2RYMRYQuw==.hmV03t1ecH5axEB04F/9KfaQJREvF+WE8AViPyZsOjg=" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotifyAssessments_StudentId",
                table: "StudentNotifyAssessments",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentNotifyAssessments");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 28, 1, 28, 43, 464, DateTimeKind.Utc).AddTicks(143), "PBKDF2-HMACSHA256.210000.wbvxM+cz9L7OdzuyMcjkOg==.ZGyzI9bsg334N1AGAErz6HoqQQU/i4BjR+Xls3q9SqU=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 28, 1, 28, 43, 439, DateTimeKind.Utc).AddTicks(5210), "PBKDF2-HMACSHA256.210000.5q1J4zX8Hlzjdx+5Li4a7A==.A8SYFA01Ncw+iijOJ5jbDkOt9oEZVZPuZf3aUJ72sh4=" });
        }
    }
}
