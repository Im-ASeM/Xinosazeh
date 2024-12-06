using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorfe.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkCategories_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkCatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCategories_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPosts_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mainImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    footer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPosts_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPC_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkCatId = table.Column<int>(type: "int", nullable: false),
                    WorkPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPC_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPC_tbl_WorkCategories_tbl_WorkCatId",
                        column: x => x.WorkCatId,
                        principalTable: "WorkCategories_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkPC_tbl_WorkPosts_tbl_WorkPostId",
                        column: x => x.WorkPostId,
                        principalTable: "WorkPosts_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkPC_tbl_WorkCatId",
                table: "WorkPC_tbl",
                column: "WorkCatId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPC_tbl_WorkPostId",
                table: "WorkPC_tbl",
                column: "WorkPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkPC_tbl");

            migrationBuilder.DropTable(
                name: "WorkCategories_tbl");

            migrationBuilder.DropTable(
                name: "WorkPosts_tbl");
        }
    }
}
