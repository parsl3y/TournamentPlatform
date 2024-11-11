using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_image", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_images_games_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nick_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                    table.ForeignKey(
                        name: "FK_Player_Country",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Game",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_image_game_id",
                table: "game_image",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_country_id",
                table: "players",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_game_id",
                table: "players",
                column: "game_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_image");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
