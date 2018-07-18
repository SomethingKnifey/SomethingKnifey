using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations.ApplicationDb
{
    public partial class LEorMilitaryCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMilitaryOrLE",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMilitaryOrLE",
                table: "AspNetUsers");
        }
    }
}
