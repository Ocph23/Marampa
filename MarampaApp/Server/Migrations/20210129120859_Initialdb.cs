using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarampaApp.Server.Migrations
{
    public partial class Initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Pekerjaan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pekerjaan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "TahunPelayanan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sampai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TahunPelayanan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gereja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sinode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TahunPelayananId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Baptis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomorSurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pendeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tempat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Terverifkasi = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baptis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meninggal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorSurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tempat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JemaatId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meninggal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nikah",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorSurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalMenikah = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tempat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pendeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disini = table.Column<bool>(type: "bit", nullable: false),
                    Terverifkasi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nikah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rayon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetuaId = table.Column<int>(type: "int", nullable: true),
                    SekertarisId = table.Column<int>(type: "int", nullable: true),
                    BendaharaId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rayon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keluarga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorKartuKeluarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terdaftar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RayonId = table.Column<int>(type: "int", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keluarga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keluarga_Rayon_RayonId",
                        column: x => x.RayonId,
                        principalTable: "Rayon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jemaat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<int>(type: "int", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HubunganKeluarga = table.Column<int>(type: "int", nullable: false),
                    StatusJemaat = table.Column<int>(type: "int", nullable: false),
                    KeluargaId = table.Column<int>(type: "int", nullable: true),
                    PekerjaanId = table.Column<int>(type: "int", nullable: true),
                    StatusPernikahan = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    Berkas = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomorSurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pendeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tempat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Terverifkasi = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Gereja_TahunPelayananId",
                table: "Gereja",
                column: "TahunPelayananId");

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_KeluargaId",
                table: "Jemaat",
                column: "KeluargaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_NIK",
                table: "Jemaat",
                column: "NIK",
                unique: true,
                filter: "NIK IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jemaat_PekerjaanId",
                table: "Jemaat",
                column: "PekerjaanId");

            migrationBuilder.CreateIndex(
                name: "IX_Keluarga_RayonId",
                table: "Keluarga",
                column: "RayonId");

            migrationBuilder.CreateIndex(
                name: "IX_Meninggal_JemaatId",
                table: "Meninggal",
                column: "JemaatId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

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
                name: "FK_Meninggal_Jemaat_JemaatId",
                table: "Meninggal",
                column: "JemaatId",
                principalTable: "Jemaat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Baptis");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Gereja");

            migrationBuilder.DropTable(
                name: "Meninggal");

            migrationBuilder.DropTable(
                name: "Nikah");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Sidi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TahunPelayanan");

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
