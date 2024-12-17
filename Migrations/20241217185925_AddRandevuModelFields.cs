using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class AddRandevuModelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Islem",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Randevular");

            migrationBuilder.AddColumn<int>(
                name: "IslemId",
                table: "Randevular",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_IslemId",
                table: "Randevular",
                column: "IslemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Calisanlarimiz_CalisanId",
                table: "Randevular",
                column: "CalisanId",
                principalTable: "Calisanlarimiz",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular",
                column: "IslemId",
                principalTable: "Islemler",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Calisanlarimiz_CalisanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_IslemId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "IslemId",
                table: "Randevular");

            migrationBuilder.AddColumn<string>(
                name: "Islem",
                table: "Randevular",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId",
                table: "Randevular",
                type: "TEXT",
                nullable: true);
        }
    }
}
