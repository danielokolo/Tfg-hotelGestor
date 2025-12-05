using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfg_hotelGestor.Migrations
{
    /// <inheritdoc />
    public partial class newMIgrationCorrectIssue_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProductType",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProductType",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
