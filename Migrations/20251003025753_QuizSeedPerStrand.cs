using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class QuizSeedPerStrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 2, 57, 52, 350, DateTimeKind.Utc).AddTicks(2195), "PBKDF2-HMACSHA256.210000.DHc4ta6HZpx6Ocrdpf/YuA==.FWLka5+AuoCVK7uBAFw+3iFdkT6b1VceKWt+XtHHuSo=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 2, 57, 52, 325, DateTimeKind.Utc).AddTicks(8838), "PBKDF2-HMACSHA256.210000.BKMF6d5yF1RLpgU4hyk+7w==.5OaLb5oxNXw2ZSS2LV82fPodgF75g+2ya8lQ9zuUU6Y=" });

            migrationBuilder.InsertData(
                table: "StrandQuizzes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsLive", "RandomizeOptions", "RandomizeQuestions", "StrandId", "TimeLimitSeconds", "Title", "TotalQuestions" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-777777777777"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Foundations: concepts, tools, models & terminology.", true, true, true, true, new Guid("7b8c9d1e-2f3a-4b5c-8d9e-a1b2c3d4e5f6"), 1200, "Software Dev Intro", 20 },
                    { new Guid("22222222-2222-2222-2222-777777777777"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Entrepreneurship, accounting, management, marketing, communication & problem solving basics.", true, true, true, true, new Guid("cab2e5d5-53e8-4f5e-bc1d-6d4a9f8b7e33"), 1200, "ABM Essentials", 20 },
                    { new Guid("33333333-3333-3333-3333-777777777777"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Visual communication, design principles, literacy & storytelling for HUMSS.", true, true, true, true, new Guid("2d4f6b7c-8e5a-4c3d-9f2e-7a6b5c4d3e77"), 1200, "HUMSS Visual Graphics Basics", 20 },
                    { new Guid("44444444-4444-4444-4444-777777777777"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Mechanics, electricity, energy, earth science & engineering thinking.", true, true, true, true, new Guid("1a2b3c4d-5e6f-4789-9a8b-cd1e2f3a4b22"), 1200, "STEM-Eng Core Concepts", 20 },
                    { new Guid("55555555-5555-5555-5555-777777777777"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Fundamentals of graphics tools, formats, design & multimedia careers.", true, true, true, true, new Guid("5c3f9e2d-2c4d-4e6c-9d3a-2b4e7f8a6c55"), 1200, "Graphics & Multimedia Basics", 20 },
                    { new Guid("66666666-6666-6666-6666-777777777777"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Kitchen safety, food prep, baking, service & basic entrepreneurship.", true, true, true, true, new Guid("9e8d7c6b-5a4f-4d3c-8b2a-1f6e5d4c3b99"), 1200, "Culinary Fundamentals", 20 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Biology, systems, health, lab tools, diseases & public health.", true, true, true, true, new Guid("4a3b2c1d-5e6f-4789-8a9b-bc1d2e3f4a11"), 1200, "STEM-Med Core Concepts", 20 },
                    { new Guid("88888888-8888-8888-8888-777777777777"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), "Accommodation, automation, planning, IPR, culture & systems.", true, true, true, true, new Guid("6f5b7c7c-6d5e-4a4e-9b7a-0b7e4d6a9c11"), 1200, "Tourism Fundamentals", 20 }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DisplayOrder", "IsActive", "StrandQuizId", "Text" },
                values: new object[,]
                {
                    { new Guid("10a2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of the following is used to give instructions to a computer?" },
                    { new Guid("10a2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which programming language is commonly used for web development?" },
                    { new Guid("10a2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("11111111-1111-1111-1111-777777777777"), "What does \"bug\" mean in programming?" },
                    { new Guid("10a2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which symbol is used to end a statement in Java?" },
                    { new Guid("10a2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("11111111-1111-1111-1111-777777777777"), "What does IDE stand for in programming?" },
                    { new Guid("10a2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("11111111-1111-1111-1111-777777777777"), "In coding, what does \"loop\" mean?" },
                    { new Guid("10a2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of the following is NOT a programming language?" },
                    { new Guid("10a2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("11111111-1111-1111-1111-777777777777"), "What is the first step in solving a programming problem?" },
                    { new Guid("10a2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of these is used to store multiple values in programming?" },
                    { new Guid("10a2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of the following jobs is most related to software development?" },
                    { new Guid("10a2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which programming language is often used for Artificial Intelligence and Data Science?" },
                    { new Guid("10a2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("11111111-1111-1111-1111-777777777777"), "What does GUI stand for?" },
                    { new Guid("10a2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of the following is used to manage and store data in software applications?" },
                    { new Guid("10a2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("11111111-1111-1111-1111-777777777777"), "In HTML, which tag is used to display the largest heading?" },
                    { new Guid("10a2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which of these is an open-source operating system often used by developers?" },
                    { new Guid("10a2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("11111111-1111-1111-1111-777777777777"), "What does an algorithm represent?" },
                    { new Guid("10a2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which software development model has sequential phases?" },
                    { new Guid("10a2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which type of loop will always run at least once (in most languages)?" },
                    { new Guid("10a2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("11111111-1111-1111-1111-777777777777"), "Which profession tests software to ensure it works correctly?" },
                    { new Guid("10a2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("11111111-1111-1111-1111-777777777777"), "What does API stand for in software development?" },
                    { new Guid("20c2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("33333333-3333-3333-3333-777777777777"), "What is the main purpose of visual graphics in communication?" },
                    { new Guid("20c2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("33333333-3333-3333-3333-777777777777"), "In HUMSS, “doorways” usually refer to:" },
                    { new Guid("20c2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which of the following is an example of visual communication?" },
                    { new Guid("20c2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("33333333-3333-3333-3333-777777777777"), "What principle of design is about the equal distribution of elements?" },
                    { new Guid("20c2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("33333333-3333-3333-3333-777777777777"), "A logo is mainly created to:" },
                    { new Guid("20c2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which applied subject often includes visual graphics in HUMSS?" },
                    { new Guid("20c2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which design principle emphasizes differences in color, size, or shape?" },
                    { new Guid("20c2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("33333333-3333-3333-3333-777777777777"), "A digital tool commonly used for graphic design is:" },
                    { new Guid("20c2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("33333333-3333-3333-3333-777777777777"), "What does visual storytelling aim to do?" },
                    { new Guid("20c2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("33333333-3333-3333-3333-777777777777"), "Infographics are effective because they:" },
                    { new Guid("20c2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which of the following is not a visual graphic output?" },
                    { new Guid("20c2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("33333333-3333-3333-3333-777777777777"), "Visual graphics help in journalism by:" },
                    { new Guid("20c2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("33333333-3333-3333-3333-777777777777"), "The principle of design that creates unity by repeating elements is:" },
                    { new Guid("20c2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which of the following best describes visual literacy?" },
                    { new Guid("20c2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("33333333-3333-3333-3333-777777777777"), "A layout that guides the reader’s eye smoothly across a page follows:" },
                    { new Guid("20c2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("33333333-3333-3333-3333-777777777777"), "Which software is NOT primarily for visual graphics?" },
                    { new Guid("20c2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("33333333-3333-3333-3333-777777777777"), "A poster for an advocacy campaign should mainly:" },
                    { new Guid("20c2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("33333333-3333-3333-3333-777777777777"), "Visual graphics are important in education because they:" },
                    { new Guid("20c2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("33333333-3333-3333-3333-777777777777"), "What principle of design makes one element stand out more than others?" },
                    { new Guid("20c2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("33333333-3333-3333-3333-777777777777"), "In the HUMSS strand, learning visual graphics helps students mainly by:" },
                    { new Guid("30b2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which of the following best describes entrepreneurship?" },
                    { new Guid("30b2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("22222222-2222-2222-2222-777777777777"), "The main goal of a business is to:" },
                    { new Guid("30b2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which document is commonly used when starting a business?" },
                    { new Guid("30b2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("22222222-2222-2222-2222-777777777777"), "Bookkeeping primarily deals with:" },
                    { new Guid("30b2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which financial statement shows a company’s revenues and expenses?" },
                    { new Guid("30b2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("22222222-2222-2222-2222-777777777777"), "Assets minus liabilities equals:" },
                    { new Guid("30b2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which of the following is NOT a management function?" },
                    { new Guid("30b2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("22222222-2222-2222-2222-777777777777"), "A good leader must possess which of the following qualities?" },
                    { new Guid("30b2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("22222222-2222-2222-2222-777777777777"), "Delegation in management means:" },
                    { new Guid("30b2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("22222222-2222-2222-2222-777777777777"), "Marketing focuses mainly on:" },
                    { new Guid("30b2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which is an example of a marketing tool?" },
                    { new Guid("30b2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("22222222-2222-2222-2222-777777777777"), "The 4Ps of Marketing include Product, Price, Place, and:" },
                    { new Guid("30b2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which type of communication is most important in business?" },
                    { new Guid("30b2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("22222222-2222-2222-2222-777777777777"), "A memorandum (memo) is typically used for:" },
                    { new Guid("30b2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which of the following is an example of business correspondence?" },
                    { new Guid("30b2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("22222222-2222-2222-2222-777777777777"), "Critical thinking is best described as:" },
                    { new Guid("30b2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("22222222-2222-2222-2222-777777777777"), "When solving a business problem, the first step is to:" },
                    { new Guid("30b2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("22222222-2222-2222-2222-777777777777"), "A SWOT analysis evaluates:" },
                    { new Guid("30b2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("22222222-2222-2222-2222-777777777777"), "Which college course is most directly related to accounting?" },
                    { new Guid("30b2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("22222222-2222-2222-2222-777777777777"), "The ABM strand prepares students mainly for careers in:" },
                    { new Guid("40d2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which software is widely used for photo editing?" },
                    { new Guid("40d2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following refers to the combination of text, images, audio, and video?" },
                    { new Guid("40d2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which file format is commonly used for images?" },
                    { new Guid("40d2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("55555555-5555-5555-5555-777777777777"), "What does DPI stand for in graphics?" },
                    { new Guid("40d2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following is an example of vector graphics software?" },
                    { new Guid("40d2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which color model is used for digital screens?" },
                    { new Guid("40d2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which multimedia career focuses on creating animated characters?" },
                    { new Guid("40d2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("55555555-5555-5555-5555-777777777777"), "What is the main purpose of a storyboard in multimedia projects?" },
                    { new Guid("40d2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which file format is commonly used for video files?" },
                    { new Guid("40d2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following jobs belongs to the Graphics and Multimedia pathway?" },
                    { new Guid("40d2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following is a raster-based graphic software?" },
                    { new Guid("40d2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which file format is commonly used for audio in multimedia?" },
                    { new Guid("40d2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which principle of design refers to the arrangement of elements to create stability?" },
                    { new Guid("40d2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which software is commonly used for 3D animation?" },
                    { new Guid("40d2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following refers to the smallest unit of a digital image?" },
                    { new Guid("40d2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("55555555-5555-5555-5555-777777777777"), "What does CMYK stand for in printing?" },
                    { new Guid("40d2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which principle of design highlights the difference between elements?" },
                    { new Guid("40d2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which of the following software is mainly used for video editing?" },
                    { new Guid("40d2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which multimedia element gives movement to objects or characters?" },
                    { new Guid("40d2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("55555555-5555-5555-5555-777777777777"), "Which career works mostly with visual communication and branding?" },
                    { new Guid("50e2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which organ pumps blood throughout the body?" },
                    { new Guid("50e2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which system controls movement with muscles and bones?" },
                    { new Guid("50e2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("77777777-7777-7777-7777-777777777777"), "Where does digestion begin?" },
                    { new Guid("50e2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which part of the brain controls balance and coordination?" },
                    { new Guid("50e2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which is the basic unit of life?" },
                    { new Guid("50e2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which blood cells fight against infections?" },
                    { new Guid("50e2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("77777777-7777-7777-7777-777777777777"), "Photosynthesis mainly takes place in which part of a plant?" },
                    { new Guid("50e2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which process describes how organisms pass traits to offspring?" },
                    { new Guid("50e2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which disease is caused by a lack of insulin in the body?" },
                    { new Guid("50e2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which of the following is a communicable disease?" },
                    { new Guid("50e2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("77777777-7777-7777-7777-777777777777"), "What is the main purpose of vaccines?" },
                    { new Guid("50e2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which type of energy is measured in food?" },
                    { new Guid("50e2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("77777777-7777-7777-7777-777777777777"), "In chemistry, H₂O is the formula for what substance?" },
                    { new Guid("50e2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("77777777-7777-7777-7777-777777777777"), "In medical imaging, X-rays are used to view what?" },
                    { new Guid("50e2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which global organization monitors and responds to international health emergencies?" },
                    { new Guid("50e2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which laboratory tool is used to measure liquid volume accurately?" },
                    { new Guid("50e2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which of these health problems is most studied in public health research?" },
                    { new Guid("50e2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("77777777-7777-7777-7777-777777777777"), "What is a microscope used for?" },
                    { new Guid("50e2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("77777777-7777-7777-7777-777777777777"), "Which safety item should always be worn during lab experiments?" },
                    { new Guid("50e2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("77777777-7777-7777-7777-777777777777"), "What is a stethoscope used for?" },
                    { new Guid("60f2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("66666666-6666-6666-6666-777777777777"), "Why should knives be kept sharp in the kitchen?" },
                    { new Guid("60f2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which of these is the safest way to thaw frozen meat?" },
                    { new Guid("60f2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which color chopping board is usually used for raw meat?" },
                    { new Guid("60f2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("66666666-6666-6666-6666-777777777777"), "What is the correct way to hold a knife while walking?" },
                    { new Guid("60f2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("66666666-6666-6666-6666-777777777777"), "Why should vegetables be washed before cooking?" },
                    { new Guid("60f2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which is the best practice when storing dry ingredients like flour and rice?" },
                    { new Guid("60f2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("66666666-6666-6666-6666-777777777777"), "If a recipe says ‘julienne the carrots,’ what does it mean?" },
                    { new Guid("60f2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("66666666-6666-6666-6666-777777777777"), "What is the main purpose of marinating meat?" },
                    { new Guid("60f2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which of these is a leavening agent in baking?" },
                    { new Guid("60f2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which method of cooking involves cooking food in hot oil?" },
                    { new Guid("60f2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which pastry is known for its many thin, flaky layers?" },
                    { new Guid("60f2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("66666666-6666-6666-6666-777777777777"), "What does ‘al dente’ mean when cooking pasta?" },
                    { new Guid("60f2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("66666666-6666-6666-6666-777777777777"), "What is the first thing you should do when serving food to a customer?" },
                    { new Guid("60f2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("66666666-6666-6666-6666-777777777777"), "Why is food presentation important?" },
                    { new Guid("60f2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which is an example of table service?" },
                    { new Guid("60f2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which menu type changes daily based on available ingredients?" },
                    { new Guid("60f2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("66666666-6666-6666-6666-777777777777"), "What do you call calculating the cost of ingredients to set a selling price?" },
                    { new Guid("60f2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("66666666-6666-6666-6666-777777777777"), "Why is portion control important in food business?" },
                    { new Guid("60f2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("66666666-6666-6666-6666-777777777777"), "Which is the BEST way to attract more customers to your food business?" },
                    { new Guid("60f2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("66666666-6666-6666-6666-777777777777"), "If you dream of opening your own restaurant, which skill besides cooking is MOST important?" },
                    { new Guid("70e2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("44444444-4444-4444-4444-777777777777"), "What is the unit of force in mechanics?" },
                    { new Guid("70e2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which law states that for every action, there is an equal and opposite reaction?" },
                    { new Guid("70e2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("44444444-4444-4444-4444-777777777777"), "What is the formula for Ohm's Law?" },
                    { new Guid("70e2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which of the following is a renewable energy source?" },
                    { new Guid("70e2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("44444444-4444-4444-4444-777777777777"), "The ability of a material to resist being deformed by force is called:" },
                    { new Guid("70e2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which particle is responsible for electric current?" },
                    { new Guid("70e2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("44444444-4444-4444-4444-777777777777"), "What does a magnetic field surround?" },
                    { new Guid("70e2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which branch of physics studies motion and forces?" },
                    { new Guid("70e2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which is an example of a vector quantity?" },
                    { new Guid("70e2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("44444444-4444-4444-4444-777777777777"), "What layer of the Earth contains most of the Earth's mass?" },
                    { new Guid("70e2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("44444444-4444-4444-4444-777777777777"), "What is the SI unit of power?" },
                    { new Guid("70e2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("44444444-4444-4444-4444-777777777777"), "In magnetism, like poles:" },
                    { new Guid("70e2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which type of wave requires a medium to travel?" },
                    { new Guid("70e2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("44444444-4444-4444-4444-777777777777"), "What type of simple machine is a ramp?" },
                    { new Guid("70e2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("44444444-4444-4444-4444-777777777777"), "The study of earthquakes is called:" },
                    { new Guid("70e2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which gas is most abundant in Earth's atmosphere?" },
                    { new Guid("70e2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("44444444-4444-4444-4444-777777777777"), "In applied mathematics, the derivative of a constant is:" },
                    { new Guid("70e2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which of the following is an example of potential energy?" },
                    { new Guid("70e2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("44444444-4444-4444-4444-777777777777"), "What happens when an object's net force is zero?" },
                    { new Guid("70e2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("44444444-4444-4444-4444-777777777777"), "Which of the following best shows the application of engineering thinking?" },
                    { new Guid("80f2a010-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 1, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which of the following best describes accommodation in tourism?" },
                    { new Guid("80f2a020-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 2, true, new Guid("88888888-8888-8888-8888-777777777777"), "What is the main purpose of an automated system in the tourism industry?" },
                    { new Guid("80f2a030-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 3, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which of the following is a source of tourism information?" },
                    { new Guid("80f2a040-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 4, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which is an important element in a travel plan?" },
                    { new Guid("80f2a050-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 5, true, new Guid("88888888-8888-8888-8888-777777777777"), "What does IPR (Intellectual Property Rights) protect in the tourism industry?" },
                    { new Guid("80f2a060-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 6, true, new Guid("88888888-8888-8888-8888-777777777777"), "An example of electronic file handling is:" },
                    { new Guid("80f2a070-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 7, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which device is essential to operate an automated information system?" },
                    { new Guid("80f2a080-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 8, true, new Guid("88888888-8888-8888-8888-777777777777"), "Cooking international cuisines in tourism promotes:" },
                    { new Guid("80f2a090-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 9, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which is an example of tourism accommodation?" },
                    { new Guid("80f2a100-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 10, true, new Guid("88888888-8888-8888-8888-777777777777"), "The main benefit of using automated systems in travel agencies is:" },
                    { new Guid("80f2a110-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 11, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which of the following is a copyright-protected material?" },
                    { new Guid("80f2a120-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 12, true, new Guid("88888888-8888-8888-8888-777777777777"), "In tourism, a travel plan usually contains:" },
                    { new Guid("80f2a130-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 13, true, new Guid("88888888-8888-8888-8888-777777777777"), "An example of electronic file handling software is:" },
                    { new Guid("80f2a140-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 14, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which is an example of tourism promotion through food?" },
                    { new Guid("80f2a150-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 15, true, new Guid("88888888-8888-8888-8888-777777777777"), "What is the importance of intellectual property in tourism promotions?" },
                    { new Guid("80f2a160-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 16, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which of the following is NOT a type of tourism accommodation?" },
                    { new Guid("80f2a170-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 17, true, new Guid("88888888-8888-8888-8888-777777777777"), "In an automated booking system, which information is usually stored?" },
                    { new Guid("80f2a180-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 18, true, new Guid("88888888-8888-8888-8888-777777777777"), "Electronic file handling ensures:" },
                    { new Guid("80f2a190-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 19, true, new Guid("88888888-8888-8888-8888-777777777777"), "Promoting food from different cultures mainly supports:" },
                    { new Guid("80f2a200-0000-0000-0000-000000000000"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"), 20, true, new Guid("88888888-8888-8888-8888-777777777777"), "Which of the following is an example of tourism-related automated system?" }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "Letter", "QuizQuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("10a2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a010-0000-0000-0000-000000000000"), "Hardware" },
                    { new Guid("10a2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a010-0000-0000-0000-000000000000"), "Software" },
                    { new Guid("10a2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a010-0000-0000-0000-000000000000"), "Program/Code" },
                    { new Guid("10a2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a010-0000-0000-0000-000000000000"), "Database" },
                    { new Guid("10a2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a020-0000-0000-0000-000000000000"), "HTML" },
                    { new Guid("10a2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a020-0000-0000-0000-000000000000"), "Java" },
                    { new Guid("10a2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a020-0000-0000-0000-000000000000"), "Python" },
                    { new Guid("10a2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("10a2a020-0000-0000-0000-000000000000"), "All of the above" },
                    { new Guid("10a2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a030-0000-0000-0000-000000000000"), "A computer virus" },
                    { new Guid("10a2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a030-0000-0000-0000-000000000000"), "A mistake or error in code" },
                    { new Guid("10a2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a030-0000-0000-0000-000000000000"), "A type of software" },
                    { new Guid("10a2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a030-0000-0000-0000-000000000000"), "A system update" },
                    { new Guid("10a2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a040-0000-0000-0000-000000000000"), ", (comma)" },
                    { new Guid("10a2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a040-0000-0000-0000-000000000000"), ". (period)" },
                    { new Guid("10a2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a040-0000-0000-0000-000000000000"), "; (semicolon)" },
                    { new Guid("10a2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a040-0000-0000-0000-000000000000"), ": (colon)" },
                    { new Guid("10a2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a050-0000-0000-0000-000000000000"), "Internal Design Editor" },
                    { new Guid("10a2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a050-0000-0000-0000-000000000000"), "Integrated Development Environment" },
                    { new Guid("10a2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a050-0000-0000-0000-000000000000"), "Internet Data Exchange" },
                    { new Guid("10a2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a050-0000-0000-0000-000000000000"), "Interactive Debugging Engine" },
                    { new Guid("10a2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("10a2a060-0000-0000-0000-000000000000"), "Repeating a set of instructions" },
                    { new Guid("10a2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a060-0000-0000-0000-000000000000"), "Storing data in memory" },
                    { new Guid("10a2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a060-0000-0000-0000-000000000000"), "Combining two programs" },
                    { new Guid("10a2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a060-0000-0000-0000-000000000000"), "Fixing an error" },
                    { new Guid("10a2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a070-0000-0000-0000-000000000000"), "Python" },
                    { new Guid("10a2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a070-0000-0000-0000-000000000000"), "Java" },
                    { new Guid("10a2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a070-0000-0000-0000-000000000000"), "Photoshop" },
                    { new Guid("10a2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a070-0000-0000-0000-000000000000"), "C++" },
                    { new Guid("10a2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a080-0000-0000-0000-000000000000"), "Debugging" },
                    { new Guid("10a2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a080-0000-0000-0000-000000000000"), "Writing the code immediately" },
                    { new Guid("10a2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a080-0000-0000-0000-000000000000"), "Planning and understanding the problem" },
                    { new Guid("10a2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a080-0000-0000-0000-000000000000"), "Compiling the program" },
                    { new Guid("10a2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a090-0000-0000-0000-000000000000"), "Loop" },
                    { new Guid("10a2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a090-0000-0000-0000-000000000000"), "Array" },
                    { new Guid("10a2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a090-0000-0000-0000-000000000000"), "Variable" },
                    { new Guid("10a2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a090-0000-0000-0000-000000000000"), "Function" },
                    { new Guid("10a2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a100-0000-0000-0000-000000000000"), "Animator" },
                    { new Guid("10a2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a100-0000-0000-0000-000000000000"), "Game Developer" },
                    { new Guid("10a2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a100-0000-0000-0000-000000000000"), "Photographer" },
                    { new Guid("10a2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a100-0000-0000-0000-000000000000"), "Video Editor" },
                    { new Guid("10a2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a110-0000-0000-0000-000000000000"), "C" },
                    { new Guid("10a2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a110-0000-0000-0000-000000000000"), "Java" },
                    { new Guid("10a2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a110-0000-0000-0000-000000000000"), "Python" },
                    { new Guid("10a2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a110-0000-0000-0000-000000000000"), "HTML" },
                    { new Guid("10a2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a120-0000-0000-0000-000000000000"), "General User Instruction" },
                    { new Guid("10a2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a120-0000-0000-0000-000000000000"), "Graphical User Interface" },
                    { new Guid("10a2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a120-0000-0000-0000-000000000000"), "Global Utility Input" },
                    { new Guid("10a2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a120-0000-0000-0000-000000000000"), "Generated Utility Interaction" },
                    { new Guid("10a2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a130-0000-0000-0000-000000000000"), "Algorithm" },
                    { new Guid("10a2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a130-0000-0000-0000-000000000000"), "Database" },
                    { new Guid("10a2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a130-0000-0000-0000-000000000000"), "Flowchart" },
                    { new Guid("10a2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a130-0000-0000-0000-000000000000"), "Compiler" },
                    { new Guid("10a2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a140-0000-0000-0000-000000000000"), "<h6>" },
                    { new Guid("10a2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a140-0000-0000-0000-000000000000"), "<h1>" },
                    { new Guid("10a2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a140-0000-0000-0000-000000000000"), "<head>" },
                    { new Guid("10a2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a140-0000-0000-0000-000000000000"), "<title>" },
                    { new Guid("10a2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a150-0000-0000-0000-000000000000"), "Windows" },
                    { new Guid("10a2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a150-0000-0000-0000-000000000000"), "Linux" },
                    { new Guid("10a2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a150-0000-0000-0000-000000000000"), "macOS" },
                    { new Guid("10a2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a150-0000-0000-0000-000000000000"), "Android" },
                    { new Guid("10a2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("10a2a160-0000-0000-0000-000000000000"), "A step-by-step solution to a problem" },
                    { new Guid("10a2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a160-0000-0000-0000-000000000000"), "A debugging tool" },
                    { new Guid("10a2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a160-0000-0000-0000-000000000000"), "A computer virus" },
                    { new Guid("10a2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a160-0000-0000-0000-000000000000"), "A type of database" },
                    { new Guid("10a2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a170-0000-0000-0000-000000000000"), "Agile" },
                    { new Guid("10a2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("10a2a170-0000-0000-0000-000000000000"), "Waterfall" },
                    { new Guid("10a2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a170-0000-0000-0000-000000000000"), "Spiral" },
                    { new Guid("10a2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a170-0000-0000-0000-000000000000"), "Prototype" },
                    { new Guid("10a2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("10a2a180-0000-0000-0000-000000000000"), "For loop" },
                    { new Guid("10a2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a180-0000-0000-0000-000000000000"), "While loop" },
                    { new Guid("10a2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("10a2a180-0000-0000-0000-000000000000"), "Do-while loop" },
                    { new Guid("10a2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a180-0000-0000-0000-000000000000"), "Nested loop" },
                    { new Guid("10a2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("10a2a190-0000-0000-0000-000000000000"), "Software Tester" },
                    { new Guid("10a2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a190-0000-0000-0000-000000000000"), "Graphic Designer" },
                    { new Guid("10a2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a190-0000-0000-0000-000000000000"), "Animator" },
                    { new Guid("10a2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a190-0000-0000-0000-000000000000"), "Editor" },
                    { new Guid("10a2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("10a2a200-0000-0000-0000-000000000000"), "Application Programming Interface" },
                    { new Guid("10a2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("10a2a200-0000-0000-0000-000000000000"), "Advanced Program Instruction" },
                    { new Guid("10a2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("10a2a200-0000-0000-0000-000000000000"), "Algorithm Processing Input" },
                    { new Guid("10a2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("10a2a200-0000-0000-0000-000000000000"), "Automated Program Index" },
                    { new Guid("20c2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a010-0000-0000-0000-000000000000"), "To make writing longer" },
                    { new Guid("20c2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a010-0000-0000-0000-000000000000"), "To communicate ideas clearly" },
                    { new Guid("20c2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a010-0000-0000-0000-000000000000"), "To replace written text completely" },
                    { new Guid("20c2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a010-0000-0000-0000-000000000000"), "To decorate only" },
                    { new Guid("20c2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a020-0000-0000-0000-000000000000"), "Classroom doors" },
                    { new Guid("20c2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a020-0000-0000-0000-000000000000"), "Applied subjects or specializations" },
                    { new Guid("20c2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a020-0000-0000-0000-000000000000"), "Entrance exams" },
                    { new Guid("20c2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a020-0000-0000-0000-000000000000"), "Group projects" },
                    { new Guid("20c2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a030-0000-0000-0000-000000000000"), "Radio broadcast" },
                    { new Guid("20c2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a030-0000-0000-0000-000000000000"), "Poster design" },
                    { new Guid("20c2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a030-0000-0000-0000-000000000000"), "Telephone conversation" },
                    { new Guid("20c2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a030-0000-0000-0000-000000000000"), "Essay writing" },
                    { new Guid("20c2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("20c2a040-0000-0000-0000-000000000000"), "Balance" },
                    { new Guid("20c2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a040-0000-0000-0000-000000000000"), "Contrast" },
                    { new Guid("20c2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a040-0000-0000-0000-000000000000"), "Repetition" },
                    { new Guid("20c2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a040-0000-0000-0000-000000000000"), "Movement" },
                    { new Guid("20c2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a050-0000-0000-0000-000000000000"), "Entertain people" },
                    { new Guid("20c2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a050-0000-0000-0000-000000000000"), "Represent a brand or identity" },
                    { new Guid("20c2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a050-0000-0000-0000-000000000000"), "Fill space in posters" },
                    { new Guid("20c2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a050-0000-0000-0000-000000000000"), "Replace photographs" },
                    { new Guid("20c2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a060-0000-0000-0000-000000000000"), "Physical Education" },
                    { new Guid("20c2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a060-0000-0000-0000-000000000000"), "Media and Information Literacy" },
                    { new Guid("20c2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a060-0000-0000-0000-000000000000"), "Statistics" },
                    { new Guid("20c2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a060-0000-0000-0000-000000000000"), "Philosophy" },
                    { new Guid("20c2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a070-0000-0000-0000-000000000000"), "Harmony" },
                    { new Guid("20c2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a070-0000-0000-0000-000000000000"), "Contrast" },
                    { new Guid("20c2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a070-0000-0000-0000-000000000000"), "Alignment" },
                    { new Guid("20c2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a070-0000-0000-0000-000000000000"), "Unity" },
                    { new Guid("20c2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a080-0000-0000-0000-000000000000"), "Microsoft Word" },
                    { new Guid("20c2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a080-0000-0000-0000-000000000000"), "Adobe Photoshop" },
                    { new Guid("20c2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a080-0000-0000-0000-000000000000"), "Notepad" },
                    { new Guid("20c2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a080-0000-0000-0000-000000000000"), "Calculator" },
                    { new Guid("20c2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a090-0000-0000-0000-000000000000"), "Tell stories only through music" },
                    { new Guid("20c2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a090-0000-0000-0000-000000000000"), "Use visuals to support narration" },
                    { new Guid("20c2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a090-0000-0000-0000-000000000000"), "Remove written words" },
                    { new Guid("20c2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a090-0000-0000-0000-000000000000"), "Make reading more difficult" },
                    { new Guid("20c2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a100-0000-0000-0000-000000000000"), "Replace textbooks completely" },
                    { new Guid("20c2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a100-0000-0000-0000-000000000000"), "Show data in a visual, easy-to-understand form" },
                    { new Guid("20c2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a100-0000-0000-0000-000000000000"), "Focus only on photographs" },
                    { new Guid("20c2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a100-0000-0000-0000-000000000000"), "Are purely decorative" },
                    { new Guid("20c2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a110-0000-0000-0000-000000000000"), "Newsletter layout" },
                    { new Guid("20c2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a110-0000-0000-0000-000000000000"), "Painting" },
                    { new Guid("20c2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("20c2a110-0000-0000-0000-000000000000"), "Short story text" },
                    { new Guid("20c2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a110-0000-0000-0000-000000000000"), "Infographic" },
                    { new Guid("20c2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a120-0000-0000-0000-000000000000"), "Removing the need for facts" },
                    { new Guid("20c2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a120-0000-0000-0000-000000000000"), "Making news more visual and engaging" },
                    { new Guid("20c2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a120-0000-0000-0000-000000000000"), "Replacing interviews" },
                    { new Guid("20c2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a120-0000-0000-0000-000000000000"), "Avoiding storytelling" },
                    { new Guid("20c2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("20c2a130-0000-0000-0000-000000000000"), "Repetition" },
                    { new Guid("20c2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a130-0000-0000-0000-000000000000"), "Balance" },
                    { new Guid("20c2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a130-0000-0000-0000-000000000000"), "Contrast" },
                    { new Guid("20c2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a130-0000-0000-0000-000000000000"), "Emphasis" },
                    { new Guid("20c2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a140-0000-0000-0000-000000000000"), "Ability to draw realistic pictures" },
                    { new Guid("20c2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a140-0000-0000-0000-000000000000"), "Ability to interpret and create visual messages" },
                    { new Guid("20c2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a140-0000-0000-0000-000000000000"), "Skill in memorizing designs" },
                    { new Guid("20c2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a140-0000-0000-0000-000000000000"), "Knowledge of art history only" },
                    { new Guid("20c2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a150-0000-0000-0000-000000000000"), "Emphasis" },
                    { new Guid("20c2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a150-0000-0000-0000-000000000000"), "Movement" },
                    { new Guid("20c2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a150-0000-0000-0000-000000000000"), "Unity" },
                    { new Guid("20c2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a150-0000-0000-0000-000000000000"), "Scale" },
                    { new Guid("20c2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a160-0000-0000-0000-000000000000"), "Canva" },
                    { new Guid("20c2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a160-0000-0000-0000-000000000000"), "Photoshop" },
                    { new Guid("20c2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a160-0000-0000-0000-000000000000"), "PowerPoint" },
                    { new Guid("20c2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("20c2a160-0000-0000-0000-000000000000"), "Excel" },
                    { new Guid("20c2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a170-0000-0000-0000-000000000000"), "Be colorful only" },
                    { new Guid("20c2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a170-0000-0000-0000-000000000000"), "Communicate the message clearly" },
                    { new Guid("20c2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a170-0000-0000-0000-000000000000"), "Avoid text completely" },
                    { new Guid("20c2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a170-0000-0000-0000-000000000000"), "Focus only on decorations" },
                    { new Guid("20c2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a180-0000-0000-0000-000000000000"), "Distract learners with colors" },
                    { new Guid("20c2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a180-0000-0000-0000-000000000000"), "Replace teachers" },
                    { new Guid("20c2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("20c2a180-0000-0000-0000-000000000000"), "Simplify complex ideas visually" },
                    { new Guid("20c2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a180-0000-0000-0000-000000000000"), "Make exams harder" },
                    { new Guid("20c2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("20c2a190-0000-0000-0000-000000000000"), "Emphasis" },
                    { new Guid("20c2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("20c2a190-0000-0000-0000-000000000000"), "Unity" },
                    { new Guid("20c2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a190-0000-0000-0000-000000000000"), "Proportion" },
                    { new Guid("20c2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a190-0000-0000-0000-000000000000"), "Balance" },
                    { new Guid("20c2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("20c2a200-0000-0000-0000-000000000000"), "Limiting them to traditional arts" },
                    { new Guid("20c2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("20c2a200-0000-0000-0000-000000000000"), "Developing communication and creative skills" },
                    { new Guid("20c2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("20c2a200-0000-0000-0000-000000000000"), "Avoiding technology use" },
                    { new Guid("20c2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("20c2a200-0000-0000-0000-000000000000"), "Making them memorize graphic terms only" },
                    { new Guid("30b2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a010-0000-0000-0000-000000000000"), "Working for a corporation" },
                    { new Guid("30b2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a010-0000-0000-0000-000000000000"), "Starting and managing your own business" },
                    { new Guid("30b2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a010-0000-0000-0000-000000000000"), "Studying consumer behavior" },
                    { new Guid("30b2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a010-0000-0000-0000-000000000000"), "Writing financial reports" },
                    { new Guid("30b2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a020-0000-0000-0000-000000000000"), "Provide entertainment" },
                    { new Guid("30b2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a020-0000-0000-0000-000000000000"), "Maximize profit" },
                    { new Guid("30b2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a020-0000-0000-0000-000000000000"), "Create advertisements" },
                    { new Guid("30b2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a020-0000-0000-0000-000000000000"), "Conduct research" },
                    { new Guid("30b2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("30b2a030-0000-0000-0000-000000000000"), "Business Plan" },
                    { new Guid("30b2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a030-0000-0000-0000-000000000000"), "Sales Report" },
                    { new Guid("30b2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a030-0000-0000-0000-000000000000"), "Balance Sheet" },
                    { new Guid("30b2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a030-0000-0000-0000-000000000000"), "Purchase Order" },
                    { new Guid("30b2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a040-0000-0000-0000-000000000000"), "Forecasting market trends" },
                    { new Guid("30b2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a040-0000-0000-0000-000000000000"), "Recording financial transactions" },
                    { new Guid("30b2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a040-0000-0000-0000-000000000000"), "Training employees" },
                    { new Guid("30b2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a040-0000-0000-0000-000000000000"), "Promoting products" },
                    { new Guid("30b2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a050-0000-0000-0000-000000000000"), "Balance Sheet" },
                    { new Guid("30b2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a050-0000-0000-0000-000000000000"), "Statement of Cash Flows" },
                    { new Guid("30b2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("30b2a050-0000-0000-0000-000000000000"), "Income Statement" },
                    { new Guid("30b2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a050-0000-0000-0000-000000000000"), "Retained Earnings" },
                    { new Guid("30b2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a060-0000-0000-0000-000000000000"), "Profit" },
                    { new Guid("30b2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a060-0000-0000-0000-000000000000"), "Owner’s Equity" },
                    { new Guid("30b2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a060-0000-0000-0000-000000000000"), "Sales Revenue" },
                    { new Guid("30b2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a060-0000-0000-0000-000000000000"), "Cash Flow" },
                    { new Guid("30b2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a070-0000-0000-0000-000000000000"), "Planning" },
                    { new Guid("30b2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a070-0000-0000-0000-000000000000"), "Organizing" },
                    { new Guid("30b2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a070-0000-0000-0000-000000000000"), "Leading" },
                    { new Guid("30b2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("30b2a070-0000-0000-0000-000000000000"), "Consuming" },
                    { new Guid("30b2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a080-0000-0000-0000-000000000000"), "Laziness" },
                    { new Guid("30b2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a080-0000-0000-0000-000000000000"), "Integrity" },
                    { new Guid("30b2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a080-0000-0000-0000-000000000000"), "Avoiding risks" },
                    { new Guid("30b2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a080-0000-0000-0000-000000000000"), "Ignoring teamwork" },
                    { new Guid("30b2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a090-0000-0000-0000-000000000000"), "Taking all the responsibilities" },
                    { new Guid("30b2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a090-0000-0000-0000-000000000000"), "Assigning tasks to subordinates" },
                    { new Guid("30b2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a090-0000-0000-0000-000000000000"), "Ignoring employees’ needs" },
                    { new Guid("30b2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a090-0000-0000-0000-000000000000"), "Hiring only managers" },
                    { new Guid("30b2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("30b2a100-0000-0000-0000-000000000000"), "Customer needs and wants" },
                    { new Guid("30b2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a100-0000-0000-0000-000000000000"), "Employee performance" },
                    { new Guid("30b2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a100-0000-0000-0000-000000000000"), "Government policies" },
                    { new Guid("30b2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a100-0000-0000-0000-000000000000"), "Bookkeeping" },
                    { new Guid("30b2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a110-0000-0000-0000-000000000000"), "Ledger" },
                    { new Guid("30b2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a110-0000-0000-0000-000000000000"), "Advertisement" },
                    { new Guid("30b2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a110-0000-0000-0000-000000000000"), "Balance Sheet" },
                    { new Guid("30b2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a110-0000-0000-0000-000000000000"), "Bank Statement" },
                    { new Guid("30b2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a120-0000-0000-0000-000000000000"), "Plan" },
                    { new Guid("30b2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a120-0000-0000-0000-000000000000"), "People" },
                    { new Guid("30b2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("30b2a120-0000-0000-0000-000000000000"), "Promotion" },
                    { new Guid("30b2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a120-0000-0000-0000-000000000000"), "Profit" },
                    { new Guid("30b2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("30b2a130-0000-0000-0000-000000000000"), "Effective oral and written communication" },
                    { new Guid("30b2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a130-0000-0000-0000-000000000000"), "Gossiping" },
                    { new Guid("30b2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a130-0000-0000-0000-000000000000"), "Non-verbal communication only" },
                    { new Guid("30b2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a130-0000-0000-0000-000000000000"), "Using slang" },
                    { new Guid("30b2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a140-0000-0000-0000-000000000000"), "Informal chatting" },
                    { new Guid("30b2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a140-0000-0000-0000-000000000000"), "Internal communication" },
                    { new Guid("30b2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a140-0000-0000-0000-000000000000"), "Advertising products" },
                    { new Guid("30b2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a140-0000-0000-0000-000000000000"), "Financial transactions" },
                    { new Guid("30b2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a150-0000-0000-0000-000000000000"), "Love letter" },
                    { new Guid("30b2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a150-0000-0000-0000-000000000000"), "Business letter" },
                    { new Guid("30b2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a150-0000-0000-0000-000000000000"), "Poem" },
                    { new Guid("30b2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a150-0000-0000-0000-000000000000"), "Comic strip" },
                    { new Guid("30b2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a160-0000-0000-0000-000000000000"), "Guessing the answer" },
                    { new Guid("30b2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a160-0000-0000-0000-000000000000"), "Analyzing facts to form a judgment" },
                    { new Guid("30b2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a160-0000-0000-0000-000000000000"), "Memorizing formulas" },
                    { new Guid("30b2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a160-0000-0000-0000-000000000000"), "Copying others’ ideas" },
                    { new Guid("30b2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a170-0000-0000-0000-000000000000"), "Implement a solution immediately" },
                    { new Guid("30b2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a170-0000-0000-0000-000000000000"), "Identify the problem" },
                    { new Guid("30b2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a170-0000-0000-0000-000000000000"), "Evaluate alternatives" },
                    { new Guid("30b2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a170-0000-0000-0000-000000000000"), "Write a financial report" },
                    { new Guid("30b2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a180-0000-0000-0000-000000000000"), "Sales, Wages, Orders, Targets" },
                    { new Guid("30b2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a180-0000-0000-0000-000000000000"), "Strengths, Weaknesses, Opportunities, Threats" },
                    { new Guid("30b2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a180-0000-0000-0000-000000000000"), "Services, Work, Operations, Trends" },
                    { new Guid("30b2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a180-0000-0000-0000-000000000000"), "Stock, Warehouse, Output, Tools" },
                    { new Guid("30b2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("30b2a190-0000-0000-0000-000000000000"), "BS Accountancy" },
                    { new Guid("30b2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("30b2a190-0000-0000-0000-000000000000"), "BS Tourism" },
                    { new Guid("30b2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a190-0000-0000-0000-000000000000"), "BS Hospitality Management" },
                    { new Guid("30b2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a190-0000-0000-0000-000000000000"), "BS Psychology" },
                    { new Guid("30b2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("30b2a200-0000-0000-0000-000000000000"), "Medicine" },
                    { new Guid("30b2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("30b2a200-0000-0000-0000-000000000000"), "Business and Management" },
                    { new Guid("30b2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("30b2a200-0000-0000-0000-000000000000"), "Engineering" },
                    { new Guid("30b2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("30b2a200-0000-0000-0000-000000000000"), "Agriculture" },
                    { new Guid("40d2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a010-0000-0000-0000-000000000000"), "Photoshop" },
                    { new Guid("40d2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a010-0000-0000-0000-000000000000"), "Visual Studio" },
                    { new Guid("40d2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a010-0000-0000-0000-000000000000"), "Notepad++" },
                    { new Guid("40d2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a010-0000-0000-0000-000000000000"), "Eclipse" },
                    { new Guid("40d2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a020-0000-0000-0000-000000000000"), "Programming" },
                    { new Guid("40d2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a020-0000-0000-0000-000000000000"), "Multimedia" },
                    { new Guid("40d2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a020-0000-0000-0000-000000000000"), "Debugging" },
                    { new Guid("40d2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a020-0000-0000-0000-000000000000"), "Coding" },
                    { new Guid("40d2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a030-0000-0000-0000-000000000000"), ".jpg" },
                    { new Guid("40d2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a030-0000-0000-0000-000000000000"), ".exe" },
                    { new Guid("40d2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a030-0000-0000-0000-000000000000"), ".mp3" },
                    { new Guid("40d2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a030-0000-0000-0000-000000000000"), ".txt" },
                    { new Guid("40d2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a040-0000-0000-0000-000000000000"), "Digital Program Instruction" },
                    { new Guid("40d2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a040-0000-0000-0000-000000000000"), "Dots Per Inch" },
                    { new Guid("40d2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a040-0000-0000-0000-000000000000"), "Design Processing Input" },
                    { new Guid("40d2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a040-0000-0000-0000-000000000000"), "Data Print Image" },
                    { new Guid("40d2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a050-0000-0000-0000-000000000000"), "Microsoft Word" },
                    { new Guid("40d2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a050-0000-0000-0000-000000000000"), "Adobe Illustrator" },
                    { new Guid("40d2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a050-0000-0000-0000-000000000000"), "VLC Media Player" },
                    { new Guid("40d2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a050-0000-0000-0000-000000000000"), "Audacity" },
                    { new Guid("40d2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a060-0000-0000-0000-000000000000"), "CMYK" },
                    { new Guid("40d2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a060-0000-0000-0000-000000000000"), "RGB" },
                    { new Guid("40d2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a060-0000-0000-0000-000000000000"), "RBGY" },
                    { new Guid("40d2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a060-0000-0000-0000-000000000000"), "HEX" },
                    { new Guid("40d2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a070-0000-0000-0000-000000000000"), "Programmer" },
                    { new Guid("40d2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a070-0000-0000-0000-000000000000"), "Animator" },
                    { new Guid("40d2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a070-0000-0000-0000-000000000000"), "Database Admin" },
                    { new Guid("40d2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a070-0000-0000-0000-000000000000"), "Engineer" },
                    { new Guid("40d2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a080-0000-0000-0000-000000000000"), "To write code" },
                    { new Guid("40d2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a080-0000-0000-0000-000000000000"), "To plan the sequence of visuals" },
                    { new Guid("40d2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a080-0000-0000-0000-000000000000"), "To edit sound" },
                    { new Guid("40d2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a080-0000-0000-0000-000000000000"), "To test software" },
                    { new Guid("40d2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a090-0000-0000-0000-000000000000"), ".mp4" },
                    { new Guid("40d2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a090-0000-0000-0000-000000000000"), ".docx" },
                    { new Guid("40d2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a090-0000-0000-0000-000000000000"), ".pptx" },
                    { new Guid("40d2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a090-0000-0000-0000-000000000000"), ".xls" },
                    { new Guid("40d2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a100-0000-0000-0000-000000000000"), "Game Designer" },
                    { new Guid("40d2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a100-0000-0000-0000-000000000000"), "Software Engineer" },
                    { new Guid("40d2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a100-0000-0000-0000-000000000000"), "Surgeon" },
                    { new Guid("40d2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a100-0000-0000-0000-000000000000"), "Accountant" },
                    { new Guid("40d2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a110-0000-0000-0000-000000000000"), "Adobe Photoshop" },
                    { new Guid("40d2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a110-0000-0000-0000-000000000000"), "Adobe Illustrator" },
                    { new Guid("40d2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a110-0000-0000-0000-000000000000"), "CorelDRAW" },
                    { new Guid("40d2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a110-0000-0000-0000-000000000000"), "SketchUp" },
                    { new Guid("40d2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a120-0000-0000-0000-000000000000"), ".png" },
                    { new Guid("40d2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a120-0000-0000-0000-000000000000"), ".mp3" },
                    { new Guid("40d2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a120-0000-0000-0000-000000000000"), ".gif" },
                    { new Guid("40d2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a120-0000-0000-0000-000000000000"), ".exe" },
                    { new Guid("40d2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a130-0000-0000-0000-000000000000"), "Balance" },
                    { new Guid("40d2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a130-0000-0000-0000-000000000000"), "Contrast" },
                    { new Guid("40d2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a130-0000-0000-0000-000000000000"), "Rhythm" },
                    { new Guid("40d2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a130-0000-0000-0000-000000000000"), "Emphasis" },
                    { new Guid("40d2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a140-0000-0000-0000-000000000000"), "Blender" },
                    { new Guid("40d2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a140-0000-0000-0000-000000000000"), "Notepad" },
                    { new Guid("40d2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a140-0000-0000-0000-000000000000"), "Microsoft Word" },
                    { new Guid("40d2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a140-0000-0000-0000-000000000000"), "MySQL" },
                    { new Guid("40d2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a150-0000-0000-0000-000000000000"), "Pixel" },
                    { new Guid("40d2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a150-0000-0000-0000-000000000000"), "Byte" },
                    { new Guid("40d2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a150-0000-0000-0000-000000000000"), "Dot" },
                    { new Guid("40d2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a150-0000-0000-0000-000000000000"), "Node" },
                    { new Guid("40d2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a160-0000-0000-0000-000000000000"), "Color Mode for Yellow and Keys" },
                    { new Guid("40d2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a160-0000-0000-0000-000000000000"), "Cyan, Magenta, Yellow, Black" },
                    { new Guid("40d2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a160-0000-0000-0000-000000000000"), "Clear, Mix, Yellow, Kinetic" },
                    { new Guid("40d2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a160-0000-0000-0000-000000000000"), "Computer Mixed Yield Keys" },
                    { new Guid("40d2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("40d2a170-0000-0000-0000-000000000000"), "Unity" },
                    { new Guid("40d2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("40d2a170-0000-0000-0000-000000000000"), "Contrast" },
                    { new Guid("40d2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a170-0000-0000-0000-000000000000"), "Alignment" },
                    { new Guid("40d2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a170-0000-0000-0000-000000000000"), "Proportion" },
                    { new Guid("40d2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a180-0000-0000-0000-000000000000"), "Adobe Premiere Pro" },
                    { new Guid("40d2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a180-0000-0000-0000-000000000000"), "AutoCAD" },
                    { new Guid("40d2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a180-0000-0000-0000-000000000000"), "NetBeans" },
                    { new Guid("40d2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a180-0000-0000-0000-000000000000"), "Eclipse" },
                    { new Guid("40d2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a190-0000-0000-0000-000000000000"), "Animation" },
                    { new Guid("40d2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a190-0000-0000-0000-000000000000"), "Typography" },
                    { new Guid("40d2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a190-0000-0000-0000-000000000000"), "Layout" },
                    { new Guid("40d2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a190-0000-0000-0000-000000000000"), "Storyboard" },
                    { new Guid("40d2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("40d2a200-0000-0000-0000-000000000000"), "Graphic Designer" },
                    { new Guid("40d2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("40d2a200-0000-0000-0000-000000000000"), "Database Manager" },
                    { new Guid("40d2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("40d2a200-0000-0000-0000-000000000000"), "Civil Engineer" },
                    { new Guid("40d2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("40d2a200-0000-0000-0000-000000000000"), "Programmer" },
                    { new Guid("50e2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a010-0000-0000-0000-000000000000"), "Lungs" },
                    { new Guid("50e2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a010-0000-0000-0000-000000000000"), "Heart" },
                    { new Guid("50e2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a010-0000-0000-0000-000000000000"), "Brain" },
                    { new Guid("50e2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a010-0000-0000-0000-000000000000"), "Kidney" },
                    { new Guid("50e2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a020-0000-0000-0000-000000000000"), "Digestive system" },
                    { new Guid("50e2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a020-0000-0000-0000-000000000000"), "Musculoskeletal system" },
                    { new Guid("50e2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a020-0000-0000-0000-000000000000"), "Circulatory system" },
                    { new Guid("50e2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a020-0000-0000-0000-000000000000"), "Nervous system" },
                    { new Guid("50e2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a030-0000-0000-0000-000000000000"), "Stomach" },
                    { new Guid("50e2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a030-0000-0000-0000-000000000000"), "Mouth" },
                    { new Guid("50e2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a030-0000-0000-0000-000000000000"), "Small intestine" },
                    { new Guid("50e2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a030-0000-0000-0000-000000000000"), "Esophagus" },
                    { new Guid("50e2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a040-0000-0000-0000-000000000000"), "Cerebrum" },
                    { new Guid("50e2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a040-0000-0000-0000-000000000000"), "Cerebellum" },
                    { new Guid("50e2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a040-0000-0000-0000-000000000000"), "Medulla oblongata" },
                    { new Guid("50e2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a040-0000-0000-0000-000000000000"), "Hypothalamus" },
                    { new Guid("50e2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a050-0000-0000-0000-000000000000"), "Atom" },
                    { new Guid("50e2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a050-0000-0000-0000-000000000000"), "Cell" },
                    { new Guid("50e2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a050-0000-0000-0000-000000000000"), "Tissue" },
                    { new Guid("50e2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a050-0000-0000-0000-000000000000"), "Organ" },
                    { new Guid("50e2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a060-0000-0000-0000-000000000000"), "Red blood cells" },
                    { new Guid("50e2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a060-0000-0000-0000-000000000000"), "Platelets" },
                    { new Guid("50e2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("50e2a060-0000-0000-0000-000000000000"), "White blood cells" },
                    { new Guid("50e2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a060-0000-0000-0000-000000000000"), "Plasma cells" },
                    { new Guid("50e2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a070-0000-0000-0000-000000000000"), "Roots" },
                    { new Guid("50e2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a070-0000-0000-0000-000000000000"), "Stem" },
                    { new Guid("50e2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("50e2a070-0000-0000-0000-000000000000"), "Leaves" },
                    { new Guid("50e2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a070-0000-0000-0000-000000000000"), "Flowers" },
                    { new Guid("50e2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a080-0000-0000-0000-000000000000"), "Respiration" },
                    { new Guid("50e2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a080-0000-0000-0000-000000000000"), "Digestion" },
                    { new Guid("50e2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("50e2a080-0000-0000-0000-000000000000"), "Heredity" },
                    { new Guid("50e2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a080-0000-0000-0000-000000000000"), "Circulation" },
                    { new Guid("50e2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a090-0000-0000-0000-000000000000"), "Asthma" },
                    { new Guid("50e2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a090-0000-0000-0000-000000000000"), "Diabetes" },
                    { new Guid("50e2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a090-0000-0000-0000-000000000000"), "Tuberculosis" },
                    { new Guid("50e2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a090-0000-0000-0000-000000000000"), "Hypertension" },
                    { new Guid("50e2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a100-0000-0000-0000-000000000000"), "Cancer" },
                    { new Guid("50e2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a100-0000-0000-0000-000000000000"), "Flu (Influenza)" },
                    { new Guid("50e2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a100-0000-0000-0000-000000000000"), "Diabetes" },
                    { new Guid("50e2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a100-0000-0000-0000-000000000000"), "Asthma" },
                    { new Guid("50e2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a110-0000-0000-0000-000000000000"), "To cure illnesses immediately" },
                    { new Guid("50e2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a110-0000-0000-0000-000000000000"), "To boost immunity and prevent diseases" },
                    { new Guid("50e2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a110-0000-0000-0000-000000000000"), "To remove toxins from the body" },
                    { new Guid("50e2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a110-0000-0000-0000-000000000000"), "To strengthen muscles" },
                    { new Guid("50e2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a120-0000-0000-0000-000000000000"), "Light energy" },
                    { new Guid("50e2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a120-0000-0000-0000-000000000000"), "Heat energy" },
                    { new Guid("50e2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a120-0000-0000-0000-000000000000"), "Electrical energy" },
                    { new Guid("50e2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("50e2a120-0000-0000-0000-000000000000"), "Chemical energy" },
                    { new Guid("50e2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a130-0000-0000-0000-000000000000"), "Salt" },
                    { new Guid("50e2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a130-0000-0000-0000-000000000000"), "Water" },
                    { new Guid("50e2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a130-0000-0000-0000-000000000000"), "Oxygen" },
                    { new Guid("50e2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a130-0000-0000-0000-000000000000"), "Carbon dioxide" },
                    { new Guid("50e2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a140-0000-0000-0000-000000000000"), "Muscles" },
                    { new Guid("50e2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a140-0000-0000-0000-000000000000"), "Bones" },
                    { new Guid("50e2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a140-0000-0000-0000-000000000000"), "Skin" },
                    { new Guid("50e2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a140-0000-0000-0000-000000000000"), "Blood" },
                    { new Guid("50e2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a150-0000-0000-0000-000000000000"), "Red Cross" },
                    { new Guid("50e2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a150-0000-0000-0000-000000000000"), "United Nations" },
                    { new Guid("50e2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("50e2a150-0000-0000-0000-000000000000"), "World Health Organization (WHO)" },
                    { new Guid("50e2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a150-0000-0000-0000-000000000000"), "CDC" },
                    { new Guid("50e2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a160-0000-0000-0000-000000000000"), "Beaker" },
                    { new Guid("50e2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a160-0000-0000-0000-000000000000"), "Test tube" },
                    { new Guid("50e2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("50e2a160-0000-0000-0000-000000000000"), "Graduated cylinder" },
                    { new Guid("50e2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a160-0000-0000-0000-000000000000"), "Petri dish" },
                    { new Guid("50e2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a170-0000-0000-0000-000000000000"), "Global warming" },
                    { new Guid("50e2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a170-0000-0000-0000-000000000000"), "Infectious diseases" },
                    { new Guid("50e2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a170-0000-0000-0000-000000000000"), "Car design" },
                    { new Guid("50e2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a170-0000-0000-0000-000000000000"), "Mobile apps" },
                    { new Guid("50e2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("50e2a180-0000-0000-0000-000000000000"), "To see very small organisms or cells" },
                    { new Guid("50e2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("50e2a180-0000-0000-0000-000000000000"), "To measure weight" },
                    { new Guid("50e2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a180-0000-0000-0000-000000000000"), "To magnify stars in the sky" },
                    { new Guid("50e2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a180-0000-0000-0000-000000000000"), "To cook food" },
                    { new Guid("50e2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a190-0000-0000-0000-000000000000"), "Sunglasses" },
                    { new Guid("50e2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a190-0000-0000-0000-000000000000"), "Lab coat and goggles" },
                    { new Guid("50e2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a190-0000-0000-0000-000000000000"), "Chef’s hat" },
                    { new Guid("50e2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a190-0000-0000-0000-000000000000"), "Sports shoes" },
                    { new Guid("50e2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("50e2a200-0000-0000-0000-000000000000"), "To check blood pressure" },
                    { new Guid("50e2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("50e2a200-0000-0000-0000-000000000000"), "To listen to heartbeats and breathing" },
                    { new Guid("50e2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("50e2a200-0000-0000-0000-000000000000"), "To measure temperature" },
                    { new Guid("50e2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("50e2a200-0000-0000-0000-000000000000"), "To test eyesight" },
                    { new Guid("60f2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a010-0000-0000-0000-000000000000"), "To cut faster" },
                    { new Guid("60f2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a010-0000-0000-0000-000000000000"), "To reduce accidents and make cutting easier" },
                    { new Guid("60f2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a010-0000-0000-0000-000000000000"), "To look professional" },
                    { new Guid("60f2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a010-0000-0000-0000-000000000000"), "To impress customers" },
                    { new Guid("60f2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a020-0000-0000-0000-000000000000"), "On the kitchen counter" },
                    { new Guid("60f2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a020-0000-0000-0000-000000000000"), "Under direct sunlight" },
                    { new Guid("60f2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("60f2a020-0000-0000-0000-000000000000"), "In the refrigerator" },
                    { new Guid("60f2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a020-0000-0000-0000-000000000000"), "In hot water" },
                    { new Guid("60f2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a030-0000-0000-0000-000000000000"), "Red" },
                    { new Guid("60f2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a030-0000-0000-0000-000000000000"), "Blue" },
                    { new Guid("60f2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a030-0000-0000-0000-000000000000"), "Green" },
                    { new Guid("60f2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a030-0000-0000-0000-000000000000"), "Yellow" },
                    { new Guid("60f2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a040-0000-0000-0000-000000000000"), "Pointing it forward" },
                    { new Guid("60f2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a040-0000-0000-0000-000000000000"), "Pointing it upward" },
                    { new Guid("60f2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("60f2a040-0000-0000-0000-000000000000"), "Holding it at your side with the blade facing down" },
                    { new Guid("60f2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a040-0000-0000-0000-000000000000"), "Hiding it behind your back" },
                    { new Guid("60f2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a050-0000-0000-0000-000000000000"), "To remove dirt and chemicals" },
                    { new Guid("60f2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a050-0000-0000-0000-000000000000"), "To make them taste better" },
                    { new Guid("60f2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a050-0000-0000-0000-000000000000"), "To change their color" },
                    { new Guid("60f2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a050-0000-0000-0000-000000000000"), "To cook them faster" },
                    { new Guid("60f2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a060-0000-0000-0000-000000000000"), "Leave them in plastic bags" },
                    { new Guid("60f2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a060-0000-0000-0000-000000000000"), "Store in airtight containers" },
                    { new Guid("60f2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a060-0000-0000-0000-000000000000"), "Keep them near the stove" },
                    { new Guid("60f2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a060-0000-0000-0000-000000000000"), "Put them in the refrigerator" },
                    { new Guid("60f2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a070-0000-0000-0000-000000000000"), "Dice into cubes" },
                    { new Guid("60f2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a070-0000-0000-0000-000000000000"), "Slice into thin strips" },
                    { new Guid("60f2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a070-0000-0000-0000-000000000000"), "Chop into small pieces" },
                    { new Guid("60f2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a070-0000-0000-0000-000000000000"), "Mash into paste" },
                    { new Guid("60f2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a080-0000-0000-0000-000000000000"), "To make it colorful" },
                    { new Guid("60f2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a080-0000-0000-0000-000000000000"), "To make it soft and flavorful" },
                    { new Guid("60f2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a080-0000-0000-0000-000000000000"), "To cook it halfway" },
                    { new Guid("60f2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a080-0000-0000-0000-000000000000"), "To make it look bigger" },
                    { new Guid("60f2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a090-0000-0000-0000-000000000000"), "Sugar" },
                    { new Guid("60f2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a090-0000-0000-0000-000000000000"), "Baking powder" },
                    { new Guid("60f2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a090-0000-0000-0000-000000000000"), "Salt" },
                    { new Guid("60f2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a090-0000-0000-0000-000000000000"), "Butter" },
                    { new Guid("60f2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a100-0000-0000-0000-000000000000"), "Boiling" },
                    { new Guid("60f2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a100-0000-0000-0000-000000000000"), "Frying" },
                    { new Guid("60f2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a100-0000-0000-0000-000000000000"), "Steaming" },
                    { new Guid("60f2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a100-0000-0000-0000-000000000000"), "Stewing" },
                    { new Guid("60f2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a110-0000-0000-0000-000000000000"), "Croissant" },
                    { new Guid("60f2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a110-0000-0000-0000-000000000000"), "Muffin" },
                    { new Guid("60f2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a110-0000-0000-0000-000000000000"), "Donut" },
                    { new Guid("60f2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a110-0000-0000-0000-000000000000"), "Brownie" },
                    { new Guid("60f2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a120-0000-0000-0000-000000000000"), "Overcooked and mushy" },
                    { new Guid("60f2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a120-0000-0000-0000-000000000000"), "Slightly firm to the bite" },
                    { new Guid("60f2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a120-0000-0000-0000-000000000000"), "Undercooked" },
                    { new Guid("60f2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a120-0000-0000-0000-000000000000"), "Burnt on the edges" },
                    { new Guid("60f2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a130-0000-0000-0000-000000000000"), "Smile and greet politely" },
                    { new Guid("60f2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a130-0000-0000-0000-000000000000"), "Serve food immediately" },
                    { new Guid("60f2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a130-0000-0000-0000-000000000000"), "Ask for payment first" },
                    { new Guid("60f2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a130-0000-0000-0000-000000000000"), "Walk away silently" },
                    { new Guid("60f2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a140-0000-0000-0000-000000000000"), "It makes food last longer" },
                    { new Guid("60f2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a140-0000-0000-0000-000000000000"), "It makes food more attractive and appetizing" },
                    { new Guid("60f2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a140-0000-0000-0000-000000000000"), "It cooks food faster" },
                    { new Guid("60f2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a140-0000-0000-0000-000000000000"), "It helps food stay hot" },
                    { new Guid("60f2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a150-0000-0000-0000-000000000000"), "Customers cook their own food" },
                    { new Guid("60f2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("60f2a150-0000-0000-0000-000000000000"), "Food is placed on the table by waiters" },
                    { new Guid("60f2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a150-0000-0000-0000-000000000000"), "Guests bring their own food" },
                    { new Guid("60f2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a150-0000-0000-0000-000000000000"), "Food is served in the kitchen only" },
                    { new Guid("60f2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a160-0000-0000-0000-000000000000"), "A la carte" },
                    { new Guid("60f2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a160-0000-0000-0000-000000000000"), "Static menu" },
                    { new Guid("60f2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a160-0000-0000-0000-000000000000"), "Table d’hôte" },
                    { new Guid("60f2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("60f2a160-0000-0000-0000-000000000000"), "Market menu" },
                    { new Guid("60f2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a170-0000-0000-0000-000000000000"), "Pricing" },
                    { new Guid("60f2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a170-0000-0000-0000-000000000000"), "Budgeting" },
                    { new Guid("60f2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("60f2a170-0000-0000-0000-000000000000"), "Food costing" },
                    { new Guid("60f2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a170-0000-0000-0000-000000000000"), "Estimating" },
                    { new Guid("60f2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a180-0000-0000-0000-000000000000"), "To avoid food waste and control costs" },
                    { new Guid("60f2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a180-0000-0000-0000-000000000000"), "To make food look bigger" },
                    { new Guid("60f2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a180-0000-0000-0000-000000000000"), "To make customers order more" },
                    { new Guid("60f2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a180-0000-0000-0000-000000000000"), "To cook faster" },
                    { new Guid("60f2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("60f2a190-0000-0000-0000-000000000000"), "Keep prices high" },
                    { new Guid("60f2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a190-0000-0000-0000-000000000000"), "Offer poor service" },
                    { new Guid("60f2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("60f2a190-0000-0000-0000-000000000000"), "Provide good quality food and service" },
                    { new Guid("60f2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a190-0000-0000-0000-000000000000"), "Avoid advertising" },
                    { new Guid("60f2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("60f2a200-0000-0000-0000-000000000000"), "Leadership and business management" },
                    { new Guid("60f2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("60f2a200-0000-0000-0000-000000000000"), "Sleeping early" },
                    { new Guid("60f2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("60f2a200-0000-0000-0000-000000000000"), "Memorizing recipes" },
                    { new Guid("60f2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("60f2a200-0000-0000-0000-000000000000"), "Talking loudly" },
                    { new Guid("70e2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a010-0000-0000-0000-000000000000"), "Joule" },
                    { new Guid("70e2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a010-0000-0000-0000-000000000000"), "Watt" },
                    { new Guid("70e2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a010-0000-0000-0000-000000000000"), "Newton" },
                    { new Guid("70e2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a010-0000-0000-0000-000000000000"), "Pascal" },
                    { new Guid("70e2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a020-0000-0000-0000-000000000000"), "Newton's First Law" },
                    { new Guid("70e2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a020-0000-0000-0000-000000000000"), "Newton's Second Law" },
                    { new Guid("70e2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a020-0000-0000-0000-000000000000"), "Newton's Third Law" },
                    { new Guid("70e2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a020-0000-0000-0000-000000000000"), "Law of Gravitation" },
                    { new Guid("70e2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a030-0000-0000-0000-000000000000"), "P = IV" },
                    { new Guid("70e2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a030-0000-0000-0000-000000000000"), "V = IR" },
                    { new Guid("70e2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a030-0000-0000-0000-000000000000"), "F = ma" },
                    { new Guid("70e2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a030-0000-0000-0000-000000000000"), "Q = mcΔT" },
                    { new Guid("70e2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a040-0000-0000-0000-000000000000"), "Coal" },
                    { new Guid("70e2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a040-0000-0000-0000-000000000000"), "Oil" },
                    { new Guid("70e2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a040-0000-0000-0000-000000000000"), "Solar energy" },
                    { new Guid("70e2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a040-0000-0000-0000-000000000000"), "Natural gas" },
                    { new Guid("70e2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("70e2a050-0000-0000-0000-000000000000"), "Elasticity" },
                    { new Guid("70e2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a050-0000-0000-0000-000000000000"), "Conductivity" },
                    { new Guid("70e2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a050-0000-0000-0000-000000000000"), "Magnetism" },
                    { new Guid("70e2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a050-0000-0000-0000-000000000000"), "Density" },
                    { new Guid("70e2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a060-0000-0000-0000-000000000000"), "Proton" },
                    { new Guid("70e2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a060-0000-0000-0000-000000000000"), "Neutron" },
                    { new Guid("70e2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a060-0000-0000-0000-000000000000"), "Electron" },
                    { new Guid("70e2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a060-0000-0000-0000-000000000000"), "Photon" },
                    { new Guid("70e2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("70e2a070-0000-0000-0000-000000000000"), "A moving electron" },
                    { new Guid("70e2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a070-0000-0000-0000-000000000000"), "A resting electron" },
                    { new Guid("70e2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a070-0000-0000-0000-000000000000"), "A piece of wood" },
                    { new Guid("70e2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a070-0000-0000-0000-000000000000"), "A plastic rod" },
                    { new Guid("70e2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a080-0000-0000-0000-000000000000"), "Optics" },
                    { new Guid("70e2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a080-0000-0000-0000-000000000000"), "Mechanics" },
                    { new Guid("70e2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a080-0000-0000-0000-000000000000"), "Thermodynamics" },
                    { new Guid("70e2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a080-0000-0000-0000-000000000000"), "Quantum physics" },
                    { new Guid("70e2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a090-0000-0000-0000-000000000000"), "Mass" },
                    { new Guid("70e2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a090-0000-0000-0000-000000000000"), "Speed" },
                    { new Guid("70e2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a090-0000-0000-0000-000000000000"), "Velocity" },
                    { new Guid("70e2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a090-0000-0000-0000-000000000000"), "Temperature" },
                    { new Guid("70e2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a100-0000-0000-0000-000000000000"), "Crust" },
                    { new Guid("70e2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a100-0000-0000-0000-000000000000"), "Mantle" },
                    { new Guid("70e2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a100-0000-0000-0000-000000000000"), "Outer Core" },
                    { new Guid("70e2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a100-0000-0000-0000-000000000000"), "Inner Core" },
                    { new Guid("70e2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a110-0000-0000-0000-000000000000"), "Joule" },
                    { new Guid("70e2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a110-0000-0000-0000-000000000000"), "Watt" },
                    { new Guid("70e2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a110-0000-0000-0000-000000000000"), "Newton" },
                    { new Guid("70e2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a110-0000-0000-0000-000000000000"), "Volt" },
                    { new Guid("70e2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a120-0000-0000-0000-000000000000"), "Attract" },
                    { new Guid("70e2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a120-0000-0000-0000-000000000000"), "Repel" },
                    { new Guid("70e2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a120-0000-0000-0000-000000000000"), "Neutralize" },
                    { new Guid("70e2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a120-0000-0000-0000-000000000000"), "Overlap" },
                    { new Guid("70e2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a130-0000-0000-0000-000000000000"), "Electromagnetic wave" },
                    { new Guid("70e2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a130-0000-0000-0000-000000000000"), "Sound wave" },
                    { new Guid("70e2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a130-0000-0000-0000-000000000000"), "Light wave" },
                    { new Guid("70e2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a130-0000-0000-0000-000000000000"), "Gamma ray" },
                    { new Guid("70e2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a140-0000-0000-0000-000000000000"), "Lever" },
                    { new Guid("70e2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a140-0000-0000-0000-000000000000"), "Pulley" },
                    { new Guid("70e2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a140-0000-0000-0000-000000000000"), "Inclined plane" },
                    { new Guid("70e2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a140-0000-0000-0000-000000000000"), "Wheel and axle" },
                    { new Guid("70e2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a150-0000-0000-0000-000000000000"), "Geology" },
                    { new Guid("70e2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a150-0000-0000-0000-000000000000"), "Seismology" },
                    { new Guid("70e2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a150-0000-0000-0000-000000000000"), "Meteorology" },
                    { new Guid("70e2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a150-0000-0000-0000-000000000000"), "Volcanology" },
                    { new Guid("70e2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a160-0000-0000-0000-000000000000"), "Oxygen" },
                    { new Guid("70e2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a160-0000-0000-0000-000000000000"), "Nitrogen" },
                    { new Guid("70e2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a160-0000-0000-0000-000000000000"), "Carbon dioxide" },
                    { new Guid("70e2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a160-0000-0000-0000-000000000000"), "Argon" },
                    { new Guid("70e2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("70e2a170-0000-0000-0000-000000000000"), "Zero" },
                    { new Guid("70e2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a170-0000-0000-0000-000000000000"), "One" },
                    { new Guid("70e2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a170-0000-0000-0000-000000000000"), "The constant itself" },
                    { new Guid("70e2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a170-0000-0000-0000-000000000000"), "Undefined" },
                    { new Guid("70e2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a180-0000-0000-0000-000000000000"), "A moving car" },
                    { new Guid("70e2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a180-0000-0000-0000-000000000000"), "Water stored in a dam" },
                    { new Guid("70e2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a180-0000-0000-0000-000000000000"), "Sound from a speaker" },
                    { new Guid("70e2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a180-0000-0000-0000-000000000000"), "Electric current in a wire" },
                    { new Guid("70e2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a190-0000-0000-0000-000000000000"), "It accelerates" },
                    { new Guid("70e2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("70e2a190-0000-0000-0000-000000000000"), "It changes direction" },
                    { new Guid("70e2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("70e2a190-0000-0000-0000-000000000000"), "It remains at rest or in uniform motion" },
                    { new Guid("70e2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a190-0000-0000-0000-000000000000"), "It gains energy" },
                    { new Guid("70e2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("70e2a200-0000-0000-0000-000000000000"), "Solving puzzles for fun" },
                    { new Guid("70e2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("70e2a200-0000-0000-0000-000000000000"), "Designing a bridge to carry heavy loads" },
                    { new Guid("70e2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("70e2a200-0000-0000-0000-000000000000"), "Writing a poem" },
                    { new Guid("70e2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("70e2a200-0000-0000-0000-000000000000"), "Memorizing dates of history" },
                    { new Guid("80f2a010-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a010-0000-0000-0000-000000000000"), "The transport service used by tourists" },
                    { new Guid("80f2a010-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a010-0000-0000-0000-000000000000"), "The place where tourists stay during travel" },
                    { new Guid("80f2a010-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a010-0000-0000-0000-000000000000"), "The travel documents required for entry" },
                    { new Guid("80f2a010-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a010-0000-0000-0000-000000000000"), "The promotional material for tourism" },
                    { new Guid("80f2a020-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a020-0000-0000-0000-000000000000"), "To reduce cultural promotion" },
                    { new Guid("80f2a020-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a020-0000-0000-0000-000000000000"), "To manage bookings and reservations efficiently" },
                    { new Guid("80f2a020-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a020-0000-0000-0000-000000000000"), "To replace traditional cuisines" },
                    { new Guid("80f2a020-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a020-0000-0000-0000-000000000000"), "To avoid using computers" },
                    { new Guid("80f2a030-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a030-0000-0000-0000-000000000000"), "Travel agencies" },
                    { new Guid("80f2a030-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a030-0000-0000-0000-000000000000"), "Hardware stores" },
                    { new Guid("80f2a030-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a030-0000-0000-0000-000000000000"), "Gas stations" },
                    { new Guid("80f2a030-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a030-0000-0000-0000-000000000000"), "Local police stations" },
                    { new Guid("80f2a040-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a040-0000-0000-0000-000000000000"), "Food recipes" },
                    { new Guid("80f2a040-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a040-0000-0000-0000-000000000000"), "Tourist destinations and itineraries" },
                    { new Guid("80f2a040-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a040-0000-0000-0000-000000000000"), "Dance performances" },
                    { new Guid("80f2a040-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a040-0000-0000-0000-000000000000"), "Religious rituals" },
                    { new Guid("80f2a050-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a050-0000-0000-0000-000000000000"), "Tourist visas" },
                    { new Guid("80f2a050-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a050-0000-0000-0000-000000000000"), "Cultural dances" },
                    { new Guid("80f2a050-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("80f2a050-0000-0000-0000-000000000000"), "Original creative works like logos, slogans, and software" },
                    { new Guid("80f2a050-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a050-0000-0000-0000-000000000000"), "Hotel accommodations" },
                    { new Guid("80f2a060-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a060-0000-0000-0000-000000000000"), "Printing brochures" },
                    { new Guid("80f2a060-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a060-0000-0000-0000-000000000000"), "Sending an email attachment" },
                    { new Guid("80f2a060-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a060-0000-0000-0000-000000000000"), "Writing on paper" },
                    { new Guid("80f2a060-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a060-0000-0000-0000-000000000000"), "Cooking local cuisine" },
                    { new Guid("80f2a070-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a070-0000-0000-0000-000000000000"), "Typewriter" },
                    { new Guid("80f2a070-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a070-0000-0000-0000-000000000000"), "Calculator" },
                    { new Guid("80f2a070-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("80f2a070-0000-0000-0000-000000000000"), "Computer/Laptop" },
                    { new Guid("80f2a070-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a070-0000-0000-0000-000000000000"), "Fax machine" },
                    { new Guid("80f2a080-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a080-0000-0000-0000-000000000000"), "Political unity" },
                    { new Guid("80f2a080-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a080-0000-0000-0000-000000000000"), "Cultural diversity" },
                    { new Guid("80f2a080-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a080-0000-0000-0000-000000000000"), "Business taxation" },
                    { new Guid("80f2a080-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a080-0000-0000-0000-000000000000"), "Banking" },
                    { new Guid("80f2a090-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a090-0000-0000-0000-000000000000"), "A restaurant" },
                    { new Guid("80f2a090-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a090-0000-0000-0000-000000000000"), "A hotel" },
                    { new Guid("80f2a090-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a090-0000-0000-0000-000000000000"), "An airport" },
                    { new Guid("80f2a090-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a090-0000-0000-0000-000000000000"), "A souvenir shop" },
                    { new Guid("80f2a100-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a100-0000-0000-0000-000000000000"), "Longer processing time" },
                    { new Guid("80f2a100-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a100-0000-0000-0000-000000000000"), "More errors in bookings" },
                    { new Guid("80f2a100-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "C", new Guid("80f2a100-0000-0000-0000-000000000000"), "Faster and accurate reservations" },
                    { new Guid("80f2a100-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a100-0000-0000-0000-000000000000"), "Less use of technology" },
                    { new Guid("80f2a110-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a110-0000-0000-0000-000000000000"), "A travel agency’s software" },
                    { new Guid("80f2a110-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a110-0000-0000-0000-000000000000"), "A tourist’s personal bag" },
                    { new Guid("80f2a110-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a110-0000-0000-0000-000000000000"), "A country’s weather" },
                    { new Guid("80f2a110-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a110-0000-0000-0000-000000000000"), "A public road" },
                    { new Guid("80f2a120-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a120-0000-0000-0000-000000000000"), "Student grades" },
                    { new Guid("80f2a120-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a120-0000-0000-0000-000000000000"), "Tourist itinerary and budget" },
                    { new Guid("80f2a120-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a120-0000-0000-0000-000000000000"), "Political laws" },
                    { new Guid("80f2a120-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a120-0000-0000-0000-000000000000"), "Construction materials" },
                    { new Guid("80f2a130-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a130-0000-0000-0000-000000000000"), "Microsoft Word" },
                    { new Guid("80f2a130-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a130-0000-0000-0000-000000000000"), "Paint brush" },
                    { new Guid("80f2a130-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a130-0000-0000-0000-000000000000"), "Calculator" },
                    { new Guid("80f2a130-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a130-0000-0000-0000-000000000000"), "Typewriter" },
                    { new Guid("80f2a140-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a140-0000-0000-0000-000000000000"), "Serving fast food only" },
                    { new Guid("80f2a140-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "B", new Guid("80f2a140-0000-0000-0000-000000000000"), "Offering traditional dishes from a culture" },
                    { new Guid("80f2a140-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a140-0000-0000-0000-000000000000"), "Printing textbooks" },
                    { new Guid("80f2a140-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a140-0000-0000-0000-000000000000"), "Writing travel laws" },
                    { new Guid("80f2a150-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a150-0000-0000-0000-000000000000"), "To protect original creative works from being copied" },
                    { new Guid("80f2a150-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a150-0000-0000-0000-000000000000"), "To increase taxes for travelers" },
                    { new Guid("80f2a150-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a150-0000-0000-0000-000000000000"), "To stop advertising" },
                    { new Guid("80f2a150-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a150-0000-0000-0000-000000000000"), "To reduce accommodations" },
                    { new Guid("80f2a160-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "A", new Guid("80f2a160-0000-0000-0000-000000000000"), "Resort" },
                    { new Guid("80f2a160-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a160-0000-0000-0000-000000000000"), "Hostel" },
                    { new Guid("80f2a160-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a160-0000-0000-0000-000000000000"), "Campsite" },
                    { new Guid("80f2a160-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "D", new Guid("80f2a160-0000-0000-0000-000000000000"), "Train station" },
                    { new Guid("80f2a170-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a170-0000-0000-0000-000000000000"), "Tourist’s reservation details" },
                    { new Guid("80f2a170-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a170-0000-0000-0000-000000000000"), "Tourist’s favorite colors" },
                    { new Guid("80f2a170-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a170-0000-0000-0000-000000000000"), "Tourist’s handwriting" },
                    { new Guid("80f2a170-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a170-0000-0000-0000-000000000000"), "Tourist’s childhood story" },
                    { new Guid("80f2a180-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a180-0000-0000-0000-000000000000"), "Easy storage and retrieval of data" },
                    { new Guid("80f2a180-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a180-0000-0000-0000-000000000000"), "Increase in manual errors" },
                    { new Guid("80f2a180-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a180-0000-0000-0000-000000000000"), "Slow communication" },
                    { new Guid("80f2a180-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a180-0000-0000-0000-000000000000"), "Less use of computers" },
                    { new Guid("80f2a190-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a190-0000-0000-0000-000000000000"), "Economic development and cultural tourism" },
                    { new Guid("80f2a190-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a190-0000-0000-0000-000000000000"), "Copyright violations" },
                    { new Guid("80f2a190-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a190-0000-0000-0000-000000000000"), "Less interest in tourism" },
                    { new Guid("80f2a190-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a190-0000-0000-0000-000000000000"), "Computer software development" },
                    { new Guid("80f2a200-1fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "A", new Guid("80f2a200-0000-0000-0000-000000000000"), "Airline reservation system" },
                    { new Guid("80f2a200-2fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "B", new Guid("80f2a200-0000-0000-0000-000000000000"), "Chalkboard scheduling" },
                    { new Guid("80f2a200-3fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "C", new Guid("80f2a200-0000-0000-0000-000000000000"), "Handwritten receipts" },
                    { new Guid("80f2a200-4fff-ffff-ffff-ffffffffffff"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, "D", new Guid("80f2a200-0000-0000-0000-000000000000"), "Printed brochures only" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a010-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a010-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a010-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a010-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a020-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a020-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a020-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a020-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a030-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a030-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a030-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a030-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a040-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a040-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a040-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a040-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a050-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a050-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a050-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a050-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a060-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a060-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a060-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a060-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a070-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a070-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a070-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a070-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a080-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a080-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a080-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a080-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a090-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a090-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a090-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a090-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a100-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a100-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a100-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a100-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a110-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a110-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a110-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a110-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a120-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a120-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a120-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a120-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a130-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a130-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a130-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a130-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a140-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a140-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a140-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a140-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a150-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a150-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a150-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a150-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a160-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a160-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a160-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a160-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a170-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a170-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a170-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a170-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a180-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a180-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a180-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a180-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a190-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a190-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a190-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a190-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a200-1fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a200-2fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a200-3fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestionOptions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a200-4fff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("20c2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30b2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50e2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("60f2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70e2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("80f2a200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "StrandQuizzes",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-777777777777"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 18, 1, 51, 491, DateTimeKind.Utc).AddTicks(7377), "PBKDF2-HMACSHA256.210000.fHAl8oVpRApYGBq3nU06tA==.G7y9YigYKp9RSdiuwDXcKgmW9vuFYrYoOv/jyl9WyI8=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 18, 1, 51, 466, DateTimeKind.Utc).AddTicks(3933), "PBKDF2-HMACSHA256.210000.OhNwdlakMX53EUbBXt2I1A==.MQczwXer+YMKEyk+l7+M/khM70lN2I3YDktvuly/UV0=" });
        }
    }
}
