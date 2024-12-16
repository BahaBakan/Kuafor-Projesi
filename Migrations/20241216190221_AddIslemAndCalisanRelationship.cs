using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class AddIslemAndCalisanRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    UzmanlikAlani = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.CalisanId);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<string>(type: "TEXT", nullable: true),
                    Islem = table.Column<string>(type: "TEXT", nullable: true),
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Saat = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                });

            migrationBuilder.CreateTable(
                name: "CalisanSaat",
                columns: table => new
                {
                    CalisanSaatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false),
                    CalisanlarimizCalisanId = table.Column<int>(type: "INTEGER", nullable: true),
                    Saat = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanSaat", x => x.CalisanSaatId);
                    table.ForeignKey(
                        name: "FK_CalisanSaat_Calisanlar_CalisanlarimizCalisanId",
                        column: x => x.CalisanlarimizCalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanId");
                });

            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    IslemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IslemAdi = table.Column<string>(type: "TEXT", nullable: false),
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.IslemId);
                    table.ForeignKey(
                        name: "FK_Islemler_Calisanlar_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanSaat_CalisanlarimizCalisanId",
                table: "CalisanSaat",
                column: "CalisanlarimizCalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_CalisanId",
                table: "Islemler",
                column: "CalisanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanSaat");

            migrationBuilder.DropTable(
                name: "Islemler");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Calisanlar");
        }
    }
}
