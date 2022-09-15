using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArtworkStore.Domain.Migrations
{
    public partial class InitialCartArtwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_artworks",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "artwork_id",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "author",
                table: "artworks");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "artworks",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "transport_id",
                table: "artworks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_artworks",
                table: "artworks",
                column: "id");

            migrationBuilder.CreateTable(
                name: "artwork_photo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_id = table.Column<Guid>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    artwork_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artwork_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_artwork_photo_artworks_artwork_id",
                        column: x => x.artwork_id,
                        principalTable: "artworks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_cart_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_artwork",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false),
                    artwork_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_artwork", x => new { x.cart_id, x.artwork_id });
                    table.ForeignKey(
                        name: "FK_cart_artwork_artworks_artwork_id",
                        column: x => x.artwork_id,
                        principalTable: "artworks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_artwork_cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_artworks_author_id",
                table: "artworks",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_artwork_photo_artwork_id",
                table: "artwork_photo",
                column: "artwork_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_user_id",
                table: "cart",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_artwork_artwork_id",
                table: "cart_artwork",
                column: "artwork_id");

            migrationBuilder.AddForeignKey(
                name: "FK_artworks_author_author_id",
                table: "artworks",
                column: "author_id",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artworks_author_author_id",
                table: "artworks");

            migrationBuilder.DropTable(
                name: "artwork_photo");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "cart_artwork");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_artworks",
                table: "artworks");

            migrationBuilder.DropIndex(
                name: "IX_artworks_author_id",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "id",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "transport_id",
                table: "artworks");

            migrationBuilder.AddColumn<int>(
                name: "artwork_id",
                table: "artworks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "artworks",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_artworks",
                table: "artworks",
                column: "artwork_id");
        }
    }
}
