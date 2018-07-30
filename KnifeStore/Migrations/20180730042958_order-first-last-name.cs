using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations
{
    public partial class orderfirstlastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
