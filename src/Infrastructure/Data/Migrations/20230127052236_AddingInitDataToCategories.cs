using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingInitDataToCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO ""Category""(""CategoryID"", ""Name"", ""UserID"") VALUES ('3bdca1e5-6d70-4317-95d7-9837bd883021', 'Technology', '1a26098f-8311-4f46-abad-579bef45062e');");
            migrationBuilder.Sql(@$"INSERT INTO ""Category""(""CategoryID"", ""Name"", ""UserID"") VALUES ('035f097d-d1dd-4f31-b9a7-d00ae006886a', 'Sports', '1a26098f-8311-4f46-abad-579bef45062e');");
            migrationBuilder.Sql(@$"INSERT INTO ""Category""(""CategoryID"", ""Name"", ""UserID"") VALUES ('2cf80c5b-7b2d-40d0-97eb-03b67b566784', 'Language', '1a26098f-8311-4f46-abad-579bef45062e');");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"DELETE FROM ""Category""");
        }
    }
}
