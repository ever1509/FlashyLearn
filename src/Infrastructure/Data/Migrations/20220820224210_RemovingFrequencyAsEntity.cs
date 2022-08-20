using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class RemovingFrequencyAsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Frequency",
                table: "FlashCards");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_FrequencyID",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "FrequencyID",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "FlashCards");

            migrationBuilder.AddColumn<Guid>(
                name: "FrequencyID",
                table: "FlashCards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    FrequencyID = table.Column<Guid>(type: "uuid", nullable: false),
                    Timeline = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.FrequencyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FrequencyID",
                table: "FlashCards",
                column: "FrequencyID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Frequency",
                table: "FlashCards",
                column: "FrequencyID",
                principalTable: "Frequencies",
                principalColumn: "FrequencyID");
        }
    }
}
