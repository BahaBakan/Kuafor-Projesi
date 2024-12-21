using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class AddCalismaBaslangicSaatiToCalisanlarimiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusteriAdi",
                table: "Randevular",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IslemSuresi",
                table: "Islemler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Calisanlarimiz",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Calisanlarimiz",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusteriAdi",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "IslemSuresi",
                table: "Islemler");

            migrationBuilder.DropColumn(
                name: "CalismaBaslangicSaati",
                table: "Calisanlarimiz");

            migrationBuilder.DropColumn(
                name: "CalismaBitisSaati",
                table: "Calisanlarimiz");

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Calisanlarimiz",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Calisanlarimiz",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
