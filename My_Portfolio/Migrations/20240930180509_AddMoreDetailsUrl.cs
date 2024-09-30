using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDetailsUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoreDetailsUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoreDetailsUrl",
                table: "Projects");
        }
    }
}
