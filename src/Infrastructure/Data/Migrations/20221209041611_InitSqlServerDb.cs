using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitSqlServerDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    FlashCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FrontText = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BackText = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.FlashCardID);
                    table.ForeignKey(
                        name: "FK_FlashCard_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "FlashCardTag",
                columns: table => new
                {
                    FlashCardsFlashCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsTagID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardTag", x => new { x.FlashCardsFlashCardID, x.TagsTagID });
                    table.ForeignKey(
                        name: "FK_FlashCardTag_FlashCards_FlashCardsFlashCardID",
                        column: x => x.FlashCardsFlashCardID,
                        principalTable: "FlashCards",
                        principalColumn: "FlashCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCardTag_Tag_TagsTagID",
                        column: x => x.TagsTagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardTags",
                columns: table => new
                {
                    FlashCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardTags", x => new { x.TagID, x.FlashCardID });
                    table.ForeignKey(
                        name: "FK_FlashCardTags_FlashCards_FlashCardID",
                        column: x => x.FlashCardID,
                        principalTable: "FlashCards",
                        principalColumn: "FlashCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCardTags_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_CategoryID",
                table: "FlashCards",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardTag_TagsTagID",
                table: "FlashCardTag",
                column: "TagsTagID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardTags_FlashCardID",
                table: "FlashCardTags",
                column: "FlashCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCardTag");

            migrationBuilder.DropTable(
                name: "FlashCardTags");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
