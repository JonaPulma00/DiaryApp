using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { new Guid("48ef1bc0-6d64-4965-8c86-6691628d6ff0"), "I went swimming with Paul.", new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Went swimming." },
                    { new Guid("b7a2a6c0-9c8d-4f85-9c5e-70c62b1eb81c"), "I cooked a meal for my family after a long time not seeing them", new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Cooked a meal" },
                    { new Guid("f05605bd-321b-4a87-b3ff-74da1235b9f3"), "I've been practicing chess for 5 months so I decided to put my skills on work by playing chess with my friends.", new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Played chess with my friends" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: new Guid("48ef1bc0-6d64-4965-8c86-6691628d6ff0"));

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: new Guid("b7a2a6c0-9c8d-4f85-9c5e-70c62b1eb81c"));

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: new Guid("f05605bd-321b-4a87-b3ff-74da1235b9f3"));
        }
    }
}
