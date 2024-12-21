using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCalisanSaatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanSaatler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalisanSaatler",
                columns: table => new
                {
                    CalisanSaatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalisanlarimizCalisanId = table.Column<int>(type: "INTEGER", nullable: true),
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Saat = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanSaatler", x => x.CalisanSaatId);
                    table.ForeignKey(
                        name: "FK_CalisanSaatler_Calisanlarimiz_CalisanlarimizCalisanId",
                        column: x => x.CalisanlarimizCalisanId,
                        principalTable: "Calisanlarimiz",
                        principalColumn: "CalisanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanSaatler_CalisanlarimizCalisanId",
                table: "CalisanSaatler",
                column: "CalisanlarimizCalisanId");
        }
    }
}
