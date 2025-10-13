using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nastasiu_iana_lab2.Migrations
{
    /// <inheritdoc />
    public partial class Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_PublisherID",
                table: "book",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_book_PublisherID",
                table: "book");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "book");
        }
    }
}
