using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class RandevuSınıfıdüzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "IslemId",
                table: "Randevular",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "IslemId",
                table: "Randevular",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Islemler_IslemId",
                table: "Randevular",
                column: "IslemId",
                principalTable: "Islemler",
                principalColumn: "IslemId");
        }
    }
}
