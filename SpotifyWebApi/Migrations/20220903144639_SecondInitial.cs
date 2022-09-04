using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotifyWebApi.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "genereted",
                table: "Tokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_expired",
                table: "Tokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genereted",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "is_expired",
                table: "Tokens");
        }
    }
}
