using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nastasiu_iana_lab2.Migrations
{
    /// <inheritdoc />
    public partial class Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_AuthorID",
                table: "book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Author_AuthorID",
                table: "book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Author_AuthorID",
                table: "book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_book_AuthorID",
                table: "book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "book");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
