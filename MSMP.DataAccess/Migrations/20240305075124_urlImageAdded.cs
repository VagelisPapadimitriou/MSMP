using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class urlImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "~/images/vanish in the sunset.jpg", new DateTime(2024, 3, 5, 9, 51, 23, 241, DateTimeKind.Local).AddTicks(6566) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "~/images/dark skies.jpg", new DateTime(2024, 3, 5, 9, 51, 23, 241, DateTimeKind.Local).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "~/images/fortune of time.jpg", new DateTime(2024, 3, 5, 9, 51, 23, 241, DateTimeKind.Local).AddTicks(6563) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "", new DateTime(2024, 3, 4, 23, 14, 11, 151, DateTimeKind.Local).AddTicks(6939) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "", new DateTime(2024, 3, 4, 23, 14, 11, 151, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7,
                columns: new[] { "ImageUrl", "ReleaseDate" },
                values: new object[] { "", new DateTime(2024, 3, 4, 23, 14, 11, 151, DateTimeKind.Local).AddTicks(6936) });
        }
    }
}
