using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarampaWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pekerjaan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pekerjaan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baptis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NomorSurat = table.Column<string>(nullable: true),
                    Pendeta = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Tempat = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Terverifkasi = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baptis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nikah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    NomorSurat = table.Column<string>(nullable: true),
                    Pasangan = table.Column<string>(nullable: true),
                    TanggalMenikah = table.Column<DateTime>(nullable: false),
                    Tempat = table.Column<string>(nullable: true),
                    Pendeta = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Disini = table.Column<bool>(nullable: false),
                    Terverifkasi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nikah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rayon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true),
                    KetuaId = table.Column<int>(nullable: true),
                    SekertarisId = table.Column<int>(nullable: true),
                    BendaharaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rayon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keluarga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    NomorKartuKeluarga = table.Column<string>(nullable: true),
                    Terdaftar = table.Column<DateTime>(nullable: false),
                    RayonId = table.Column<int>(nullable: false),
                    Alamat = table.Column<string>(nullable: false),
                    Telepon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keluarga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keluarga_Rayon_RayonId",
                        column: x => x.RayonId,
                        principalTable: "Rayon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jemaat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Berkas = table.Column<string>(nullable: true),
                    NIK = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: false),
                    JenisKelamin = table.Column<int>(nullable: false),
                    TanggalLahir = table.Column<DateTime>(nullable: false),
                    HubunganKeluarga = table.Column<int>(nullable: false),
                    StatusJemaat = table.Column<int>(nullable: false),
                    KeluargaId = table.Column<int>(nullable: true),
                    PekerjaanId = table.Column<int>(nullable: true),
                    StatusPernikahan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jemaat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jemaat_Keluarga_KeluargaId",
                        column: x => x.KeluargaId,
                        principalTable: "Keluarga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jemaat_Pekerjaan_PekerjaanId",
                        column: x => x.PekerjaanId,
                        principalTable: "Pekerjaan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sidi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NomorSurat = table.Column<string>(nullable: true),
                    Pendeta = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Tempat = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Terverifkasi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sidi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sidi_Jemaat_Id",
                        column: x => x.Id,
                        principalTable: "Jemaat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_KeluargaId",
                table: "Jemaat",
                column: "KeluargaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat",
                column: "NIK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_PekerjaanId",
                table: "Jemaat",
                column: "PekerjaanId");

            migrationBuilder.CreateIndex(
                name: "IX_Keluarga_RayonId",
                table: "Keluarga",
                column: "RayonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rayon_BendaharaId",
                table: "Rayon",
                column: "BendaharaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rayon_KetuaId",
                table: "Rayon",
                column: "KetuaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rayon_SekertarisId",
                table: "Rayon",
                column: "SekertarisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baptis_Jemaat_Id",
                table: "Baptis",
                column: "Id",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nikah_Jemaat_Id",
                table: "Nikah",
                column: "Id",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rayon_Jemaat_BendaharaId",
                table: "Rayon",
                column: "BendaharaId",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rayon_Jemaat_KetuaId",
                table: "Rayon",
                column: "KetuaId",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rayon_Jemaat_SekertarisId",
                table: "Rayon",
                column: "SekertarisId",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rayon_Jemaat_BendaharaId",
                table: "Rayon");

            migrationBuilder.DropForeignKey(
                name: "FK_Rayon_Jemaat_KetuaId",
                table: "Rayon");

            migrationBuilder.DropForeignKey(
                name: "FK_Rayon_Jemaat_SekertarisId",
                table: "Rayon");

            migrationBuilder.DropTable(
                name: "Baptis");

            migrationBuilder.DropTable(
                name: "Nikah");

            migrationBuilder.DropTable(
                name: "Sidi");

            migrationBuilder.DropTable(
                name: "Jemaat");

            migrationBuilder.DropTable(
                name: "Keluarga");

            migrationBuilder.DropTable(
                name: "Pekerjaan");

            migrationBuilder.DropTable(
                name: "Rayon");
        }
    }
}
