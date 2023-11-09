using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero.Migrations
{
    /// <inheritdoc />
    public partial class FKOrderDetailEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductDetail_ProductArticleNumber",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductArticleNumber",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductArticleNumber",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleNumber",
                table: "OrderDetail",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ArticleNumber",
                table: "OrderDetail",
                column: "ArticleNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductDetail_ArticleNumber",
                table: "OrderDetail",
                column: "ArticleNumber",
                principalTable: "ProductDetail",
                principalColumn: "ArticleNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductDetail_ArticleNumber",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ArticleNumber",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleNumber",
                table: "OrderDetail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "ProductArticleNumber",
                table: "OrderDetail",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductArticleNumber",
                table: "OrderDetail",
                column: "ProductArticleNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductDetail_ProductArticleNumber",
                table: "OrderDetail",
                column: "ProductArticleNumber",
                principalTable: "ProductDetail",
                principalColumn: "ArticleNumber");
        }
    }
}
