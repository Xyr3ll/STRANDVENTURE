using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddStrandQuizSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "QuestionOptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StrandQuizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TimeLimitSeconds = table.Column<int>(type: "int", nullable: true),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    RandomizeQuestions = table.Column<bool>(type: "bit", nullable: false),
                    RandomizeOptions = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrandQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrandQuizzes_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrandQuizzes_Strands_StrandId",
                        column: x => x.StrandId,
                        principalTable: "Strands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StrandQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrandQuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrandQuizQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrandQuizQuestions_StrandQuizzes_StrandQuizId",
                        column: x => x.StrandQuizId,
                        principalTable: "StrandQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 1, 44, 331, DateTimeKind.Utc).AddTicks(2853), "PBKDF2-HMACSHA256.210000.r8W6OVApi4v9PzBPFqpc8A==.Ohhuk5biW0N5025vAMxgDNJE6xoeJZLJXwj2R/d4q0k=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 1, 44, 306, DateTimeKind.Utc).AddTicks(686), "PBKDF2-HMACSHA256.210000.+i0dK0mZhfgg5x9aIwR1fw==.3xpD/vCEmOlkkkFCoubVVlYwFUU+hieyhiL4cHKBq28=" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId_IsCorrect",
                table: "QuestionOptions",
                columns: new[] { "QuestionId", "IsCorrect" },
                unique: true,
                filter: "[IsCorrect] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizQuestions_QuestionId",
                table: "StrandQuizQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizQuestions_StrandQuizId_DisplayOrder",
                table: "StrandQuizQuestions",
                columns: new[] { "StrandQuizId", "DisplayOrder" },
                unique: true,
                filter: "[DisplayOrder] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizQuestions_StrandQuizId_QuestionId",
                table: "StrandQuizQuestions",
                columns: new[] { "StrandQuizId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizzes_CreatedBy",
                table: "StrandQuizzes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizzes_StrandId_Title",
                table: "StrandQuizzes",
                columns: new[] { "StrandId", "Title" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrandQuizQuestions");

            migrationBuilder.DropTable(
                name: "StrandQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionOptions_QuestionId_IsCorrect",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "QuestionOptions");

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
        }
    }
}
