using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class GamesFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTypes");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_GameId",
                table: "Genre",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Game_GameId",
                table: "Genre",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Game_GameId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_GameId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Genre");

            migrationBuilder.CreateTable(
                name: "GenreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreTypes_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreTypes_GameId",
                table: "GenreTypes",
                column: "GameId");
        }
    }
}
