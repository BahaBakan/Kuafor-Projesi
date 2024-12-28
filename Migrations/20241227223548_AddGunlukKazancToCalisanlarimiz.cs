using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProjesi.Migrations
{
    /// <inheritdoc />
    public partial class AddGunlukKazancToCalisanlarimiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GunlukKazanc",
                table: "Calisanlarimiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GunlukKazanc",
                table: "Calisanlarimiz");
        }
    }
}
