using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nastasiu_iana_lab2.Migrations
{
    /// <inheritdoc />
    public partial class Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Author_AuthorID",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_book_BookID",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_book_PublisherID",
                table: "Book",
                newName: "IX_Book_PublisherID");

            migrationBuilder.RenameIndex(
                name: "IX_book_AuthorID",
                table: "Book",
                newName: "IX_Book_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BookID",
                table: "BookCategory",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookID",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "book");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherID",
                table: "book",
                newName: "IX_book_PublisherID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorID",
                table: "book",
                newName: "IX_book_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Author_AuthorID",
                table: "book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_book_BookID",
                table: "BookCategory",
                column: "BookID",
                principalTable: "book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
