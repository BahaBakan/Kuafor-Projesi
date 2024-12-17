using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCalisanlarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaat_Calisanlar_CalisanlarimizCalisanId",
                table: "CalisanSaat");

            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Calisanlar_CalisanId",
                table: "Islemler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanSaat",
                table: "CalisanSaat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar");

            migrationBuilder.RenameTable(
                name: "CalisanSaat",
                newName: "CalisanSaatler");

            migrationBuilder.RenameTable(
                name: "Calisanlar",
                newName: "Calisanlarimiz");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanSaat_CalisanlarimizCalisanId",
                table: "CalisanSaatler",
                newName: "IX_CalisanSaatler_CalisanlarimizCalisanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanSaatler",
                table: "CalisanSaatler",
                column: "CalisanSaatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlarimiz",
                table: "Calisanlarimiz",
                column: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaatler_Calisanlarimiz_CalisanlarimizCalisanId",
                table: "CalisanSaatler",
                column: "CalisanlarimizCalisanId",
                principalTable: "Calisanlarimiz",
                principalColumn: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Calisanlarimiz_CalisanId",
                table: "Islemler",
                column: "CalisanId",
                principalTable: "Calisanlarimiz",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaatler_Calisanlarimiz_CalisanlarimizCalisanId",
                table: "CalisanSaatler");

            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Calisanlarimiz_CalisanId",
                table: "Islemler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanSaatler",
                table: "CalisanSaatler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlarimiz",
                table: "Calisanlarimiz");

            migrationBuilder.RenameTable(
                name: "CalisanSaatler",
                newName: "CalisanSaat");

            migrationBuilder.RenameTable(
                name: "Calisanlarimiz",
                newName: "Calisanlar");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanSaatler_CalisanlarimizCalisanId",
                table: "CalisanSaat",
                newName: "IX_CalisanSaat_CalisanlarimizCalisanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanSaat",
                table: "CalisanSaat",
                column: "CalisanSaatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar",
                column: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaat_Calisanlar_CalisanlarimizCalisanId",
                table: "CalisanSaat",
                column: "CalisanlarimizCalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Calisanlar_CalisanId",
                table: "Islemler",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
