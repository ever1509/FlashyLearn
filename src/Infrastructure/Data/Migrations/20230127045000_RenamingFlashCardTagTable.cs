using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingFlashCardTagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardTags_FlashCard_FlashCardID",
                table: "FlashCardTags");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardTags_Tag_TagID",
                table: "FlashCardTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCardTags",
                table: "FlashCardTags");

            migrationBuilder.RenameTable(
                name: "FlashCardTags",
                newName: "FlashCardTag");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardTags_TagID",
                table: "FlashCardTag",
                newName: "IX_FlashCardTag_TagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCardTag",
                table: "FlashCardTag",
                columns: new[] { "FlashCardID", "TagID" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardTag_FlashCard_FlashCardID",
                table: "FlashCardTag",
                column: "FlashCardID",
                principalTable: "FlashCard",
                principalColumn: "FlashCardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardTag_Tag_TagID",
                table: "FlashCardTag",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardTag_FlashCard_FlashCardID",
                table: "FlashCardTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardTag_Tag_TagID",
                table: "FlashCardTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCardTag",
                table: "FlashCardTag");

            migrationBuilder.RenameTable(
                name: "FlashCardTag",
                newName: "FlashCardTags");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardTag_TagID",
                table: "FlashCardTags",
                newName: "IX_FlashCardTags_TagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCardTags",
                table: "FlashCardTags",
                columns: new[] { "FlashCardID", "TagID" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardTags_FlashCard_FlashCardID",
                table: "FlashCardTags",
                column: "FlashCardID",
                principalTable: "FlashCard",
                principalColumn: "FlashCardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardTags_Tag_TagID",
                table: "FlashCardTags",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
