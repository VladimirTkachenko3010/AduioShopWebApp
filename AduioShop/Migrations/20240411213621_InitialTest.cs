using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "PriceRange",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PriceRange",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
