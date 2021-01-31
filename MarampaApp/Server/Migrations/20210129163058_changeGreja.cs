using Microsoft.EntityFrameworkCore.Migrations;

namespace MarampaApp.Server.Migrations
{
    public partial class changeGreja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gereja_TahunPelayanan_TahunPelayananId",
                table: "Gereja");

            migrationBuilder.DropIndex(
                name: "IX_Gereja_TahunPelayananId",
                table: "Gereja");

            migrationBuilder.DropColumn(
                name: "TahunPelayananId",
                table: "Gereja");

            migrationBuilder.AlterColumn<string>(
                name: "Telepon",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sinode",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Klasis",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telepon",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sinode",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Klasis",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Gereja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TahunPelayananId",
                table: "Gereja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gereja_TahunPelayananId",
                table: "Gereja",
                column: "TahunPelayananId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gereja_TahunPelayanan_TahunPelayananId",
                table: "Gereja",
                column: "TahunPelayananId",
                principalTable: "TahunPelayanan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
