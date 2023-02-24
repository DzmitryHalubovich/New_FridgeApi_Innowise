using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class HideProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateOn",
                table: "Fridges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateOn",
                table: "Fridges");
        }
    }
}
