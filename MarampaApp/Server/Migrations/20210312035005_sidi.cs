using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarampaApp.Server.Migrations
{
    public partial class sidi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Berkas",
                table: "Sidi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Sidi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Sidi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Berkas",
                table: "Sidi");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Sidi");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Sidi");
        }
    }
}
