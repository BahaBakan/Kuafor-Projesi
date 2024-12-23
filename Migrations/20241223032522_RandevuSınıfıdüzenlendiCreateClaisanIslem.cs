using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class RandevuSınıfıdüzenlendiCreateClaisanIslem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanlarimizIslem");

            migrationBuilder.CreateTable(
                name: "IslemCalisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IslemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemCalisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IslemCalisanlar_Calisanlarimiz_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisanlarimiz",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IslemCalisanlar_Islemler_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islemler",
                        principalColumn: "IslemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IslemCalisanlar_CalisanId",
                table: "IslemCalisanlar",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_IslemCalisanlar_IslemId",
                table: "IslemCalisanlar",
                column: "IslemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IslemCalisanlar");

            migrationBuilder.CreateTable(
                name: "CalisanlarimizIslem",
                columns: table => new
                {
                    IslemlerIslemId = table.Column<int>(type: "INTEGER", nullable: false),
                    calisanlarCalisanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanlarimizIslem", x => new { x.IslemlerIslemId, x.calisanlarCalisanId });
                    table.ForeignKey(
                        name: "FK_CalisanlarimizIslem_Calisanlarimiz_calisanlarCalisanId",
                        column: x => x.calisanlarCalisanId,
                        principalTable: "Calisanlarimiz",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanlarimizIslem_Islemler_IslemlerIslemId",
                        column: x => x.IslemlerIslemId,
                        principalTable: "Islemler",
                        principalColumn: "IslemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanlarimizIslem_calisanlarCalisanId",
                table: "CalisanlarimizIslem",
                column: "calisanlarCalisanId");
        }
    }
}
