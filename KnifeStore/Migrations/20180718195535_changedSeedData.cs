using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations
{
    public partial class changedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image" },
                values: new object[] { "One knife to rule them all.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg" });

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Knives",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "");
        }
    }
}
