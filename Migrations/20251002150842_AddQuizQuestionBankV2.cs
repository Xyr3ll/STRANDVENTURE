using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizQuestionBankV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrandQuizQuestions");

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_StrandQuizzes_StrandQuizId",
                        column: x => x.StrandQuizId,
                        principalTable: "StrandQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Letter = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 15, 8, 41, 907, DateTimeKind.Utc).AddTicks(7156), "PBKDF2-HMACSHA256.210000.gxHIaONnb4BuN8EVP/segA==.Q2pJjI4ZKifGGTOQ9KDqgtANylaBtITN/5jN1Dct4pk=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 15, 8, 41, 883, DateTimeKind.Utc).AddTicks(1566), "PBKDF2-HMACSHA256.210000./LFqyef9uNmw3jVEK+uyWQ==.P+dxSA8W2RowpFOewWrjEGjNUpgxT1JXHoNomOav89U=" });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionOptions_QuizQuestionId_IsCorrect",
                table: "QuizQuestionOptions",
                columns: new[] { "QuizQuestionId", "IsCorrect" },
                unique: true,
                filter: "[IsCorrect] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionOptions_QuizQuestionId_Letter",
                table: "QuizQuestionOptions",
                columns: new[] { "QuizQuestionId", "Letter" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_CreatedBy",
                table: "QuizQuestions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_StrandQuizId_DisplayOrder",
                table: "QuizQuestions",
                columns: new[] { "StrandQuizId", "DisplayOrder" },
                unique: true,
                filter: "[DisplayOrder] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestionOptions");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.CreateTable(
                name: "StrandQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true)
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
                values: new object[] { new DateTime(2025, 10, 2, 14, 29, 52, 870, DateTimeKind.Utc).AddTicks(4314), "PBKDF2-HMACSHA256.210000.iauNdHGpCLYd+xsT8UecIg==.hmPIa3CaubqeZ7QJHI6a3lAckVwx08z2+dwHC3Yu4WE=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 29, 52, 846, DateTimeKind.Utc).AddTicks(1428), "PBKDF2-HMACSHA256.210000.iQzsABxQiSM7nYbHb3lssQ==./E3WIK5dWb4R1q+xCjSDVz6T8b8znP/xSKiA49TPwnM=" });

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
        }
    }
}
