using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class StudentAchievementsTblAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Category = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessmentAchievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AchievementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnlockedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ContextInfo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAchievements_StudentAssessmentAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "StudentAssessmentAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAchievements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Category", "Code", "CreatedAt", "Description", "Icon", "IsActive", "Name", "Rarity" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), "Progress", "HALFWAY_HERO", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Answered half of the questions in an assessment.", "🛤️", true, "Halfway Hero", "Common" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_Code",
                table: "Achievements",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAchievements_AchievementId",
                table: "StudentAssessmentAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAchievements_AttemptId_AchievementId",
                table: "StudentAssessmentAchievements",
                columns: new[] { "AttemptId", "AchievementId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAchievements_StudentId",
                table: "StudentAssessmentAchievements",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssessmentAchievements");

            migrationBuilder.DropTable(
                name: "Achievements");

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
        }
    }
}
