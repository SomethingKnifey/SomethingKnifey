using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations
{
    public partial class seedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "The best knife you can ever have.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "The second best knife you can ever have.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Like David Bowie, except pointer.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "This will butter your bread.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "You can buy this one if you are a spy.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Butter knife with serrated edges.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg" });

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "Another knife.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Four stars.");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 10,
                column: "Description",
                value: "International travel knife.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 10,
                column: "Description",
                value: "");
        }
    }
}
