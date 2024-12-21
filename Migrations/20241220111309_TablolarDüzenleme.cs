using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class TablolarDüzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islemler_Calisanlarimiz_CalisanId",
                table: "Islemler");

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
                name: "IX_Islemler_CalisanId",
                table: "Islemler");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Islemler");

            migrationBuilder.DropColumn(
                name: "CalismaBaslangicSaati",
                table: "Calisanlarimiz");

            migrationBuilder.DropColumn(
                name: "CalismaBitisSaati",
                table: "Calisanlarimiz");

            migrationBuilder.RenameColumn(
                name: "IslemSuresi",
                table: "Islemler",
                newName: "fiyati");

            migrationBuilder.AlterColumn<int>(
                name: "Saat",
                table: "Randevular",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "IslemId",
                table: "Randevular",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CalisanlarimizCalisanId",
                table: "Randevular",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IslemAdi",
                table: "Randevular",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calisanAdi",
                table: "Randevular",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calismaSaati",
                table: "Calisanlarimiz",
                type: "TEXT",
                nullable: true);

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
                name: "IX_Randevular_CalisanlarimizCalisanId",
                table: "Randevular",
                column: "CalisanlarimizCalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_CalisanlarimizIslem_calisanlarCalisanId",
                table: "CalisanlarimizIslem",
                column: "calisanlarCalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Calisanlarimiz_CalisanlarimizCalisanId",
                table: "Randevular",
                column: "CalisanlarimizCalisanId",
                principalTable: "Calisanlarimiz",
                principalColumn: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular",
                column: "IslemId",
                principalTable: "Islemler",
                principalColumn: "IslemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Calisanlarimiz_CalisanlarimizCalisanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "CalisanlarimizIslem");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_CalisanlarimizCalisanId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "CalisanlarimizCalisanId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "IslemAdi",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "calisanAdi",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "calismaSaati",
                table: "Calisanlarimiz");

            migrationBuilder.RenameColumn(
                name: "fiyati",
                table: "Islemler",
                newName: "IslemSuresi");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Saat",
                table: "Randevular",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "IslemId",
                table: "Randevular",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Randevular",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Islemler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalismaBaslangicSaati",
                table: "Calisanlarimiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalismaBitisSaati",
                table: "Calisanlarimiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_CalisanId",
                table: "Islemler",
                column: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Islemler_Calisanlarimiz_CalisanId",
                table: "Islemler",
                column: "CalisanId",
                principalTable: "Calisanlarimiz",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
