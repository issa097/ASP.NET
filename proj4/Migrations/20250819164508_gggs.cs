using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj4.Migrations
{
    /// <inheritdoc />
    public partial class gggs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_Books_BookId",
                table: "BorrowTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_Members_MemberId",
                table: "BorrowTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "BorrowTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BorrowTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_Books_BookId",
                table: "BorrowTransactions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_Members_MemberId",
                table: "BorrowTransactions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_Books_BookId",
                table: "BorrowTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_Members_MemberId",
                table: "BorrowTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "BorrowTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BorrowTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_Books_BookId",
                table: "BorrowTransactions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_Members_MemberId",
                table: "BorrowTransactions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
