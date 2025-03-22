using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunaPiano.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Song",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "Song",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Genre",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Artist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Artist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "age", "bio", "name" },
                values: new object[] { 25, "Bio 1", "Artist 1" });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "age", "bio", "name" },
                values: new object[] { 456, 30, "Bio 2", "Artist 2" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 123,
                column: "description",
                value: "Genre 1");

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "description" },
                values: new object[] { 456, "Genre 2" });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "album", "artist_id", "length", "title" },
                values: new object[,]
                {
                    { 123, "Album 1", 456, 180, "Song 1" },
                    { 789, "Album 2", 456, 240, "Song 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Song",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "Song",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Genre",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Artist",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Artist",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "age", "bio", "name" },
                values: new object[] { 36, "artist bio", "Stone Temple Pilots" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 123,
                column: "description",
                value: "Rock");

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "album", "artist_id", "length", "title" },
                values: new object[] { 1, "Core", 1, 313, "Plush" });
        }
    }
}
