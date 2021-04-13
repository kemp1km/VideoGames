using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class GenreFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Genre_GenreId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTypes_Genre_GenreId",
                table: "GenreTypes");

            migrationBuilder.DropIndex(
                name: "IX_Game_GenreId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreTypes",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreTypes_GenreId",
                table: "GenreTypes",
                newName: "IX_GenreTypes_GameId");

            migrationBuilder.AddColumn<string>(
                name: "GameGenre",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreId1",
                table: "Game",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Genre_GenreId1",
                table: "Game",
                column: "GenreId1",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTypes_Game_GameId",
                table: "GenreTypes",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Genre_GenreId1",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTypes_Game_GameId",
                table: "GenreTypes");

            migrationBuilder.DropIndex(
                name: "IX_Game_GenreId1",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameGenre",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GenreTypes",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreTypes_GameId",
                table: "GenreTypes",
                newName: "IX_GenreTypes_GenreId");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreId",
                table: "Game",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Genre_GenreId",
                table: "Game",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTypes_Genre_GenreId",
                table: "GenreTypes",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
