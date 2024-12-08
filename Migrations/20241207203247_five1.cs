using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorfe.Migrations
{
    /// <inheritdoc />
    public partial class five1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "footer",
                table: "WorkPosts_tbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "footer",
                table: "WorkPosts_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
