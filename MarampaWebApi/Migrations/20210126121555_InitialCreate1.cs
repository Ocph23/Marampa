using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarampaWebApi.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Keluarga",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Meninggal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    NomorSurat = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Tempat = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    JemaatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meninggal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meninggal_Jemaat_JemaatId",
                        column: x => x.JemaatId,
                        principalTable: "Jemaat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TahunPelayanan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    Mulai = table.Column<DateTime>(nullable: false),
                    Sampai = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TahunPelayanan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gereja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    Sinode = table.Column<string>(nullable: true),
                    Klasis = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Telepon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    TahunPelayananId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gereja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gereja_TahunPelayanan_TahunPelayananId",
                        column: x => x.TahunPelayananId,
                        principalTable: "TahunPelayanan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat",
                column: "NIK",
                unique: true,
                filter: "NIK IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gereja_TahunPelayananId",
                table: "Gereja",
                column: "TahunPelayananId");

            migrationBuilder.CreateIndex(
                name: "IX_Meninggal_JemaatId",
                table: "Meninggal",
                column: "JemaatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gereja");

            migrationBuilder.DropTable(
                name: "Meninggal");

            migrationBuilder.DropTable(
                name: "TahunPelayanan");

            migrationBuilder.DropIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Keluarga");

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat",
                column: "NIK",
                unique: true);
        }
    }
}
