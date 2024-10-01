using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapacitaDigitalApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesImageUploadAndUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Categories");
        }
    }
}
