using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class QuotesXPaymentOpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes_x_PaymentOptions",
                columns: table => new
                {
                    PaymentOptionsId = table.Column<int>(type: "int", nullable: false),
                    QuotesOptionId = table.Column<int>(type: "int", nullable: false),
                    QuotesOptionOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes_x_PaymentOptions", x => new { x.PaymentOptionsId, x.QuotesOptionId, x.QuotesOptionOrderId });
                    table.ForeignKey(
                        name: "FK_Quotes_x_PaymentOptions_PaymentOptions_PaymentOptionsId",
                        column: x => x.PaymentOptionsId,
                        principalTable: "PaymentOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_x_PaymentOptions_Quotes_QuotesOptionId_QuotesOptionOrderId",
                        columns: x => new { x.QuotesOptionId, x.QuotesOptionOrderId },
                        principalTable: "Quotes",
                        principalColumns: new[] { "Id", "OrderId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_x_PaymentOptions_QuotesOptionId_QuotesOptionOrderId",
                table: "Quotes_x_PaymentOptions",
                columns: new[] { "QuotesOptionId", "QuotesOptionOrderId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes_x_PaymentOptions");
        }
    }
}
