using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    /// <inheritdoc />
    public partial class CapitalLetters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "song_id",
                table: "SongGenre",
                newName: "Song_id");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "SongGenre",
                newName: "Genre_id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Song",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "length",
                table: "Song",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "artist_id",
                table: "Song",
                newName: "Artist_id");

            migrationBuilder.RenameColumn(
                name: "album",
                table: "Song",
                newName: "Album");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Genre",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Artist",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "Artist",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Artist",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Song_id",
                table: "SongGenre",
                newName: "song_id");

            migrationBuilder.RenameColumn(
                name: "Genre_id",
                table: "SongGenre",
                newName: "genre_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Song",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Song",
                newName: "length");

            migrationBuilder.RenameColumn(
                name: "Artist_id",
                table: "Song",
                newName: "artist_id");

            migrationBuilder.RenameColumn(
                name: "Album",
                table: "Song",
                newName: "album");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Genre",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artist",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Artist",
                newName: "bio");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Artist",
                newName: "age");
        }
    }
}
