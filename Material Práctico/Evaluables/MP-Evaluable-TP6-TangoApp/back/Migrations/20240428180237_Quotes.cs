using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class Quotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    SelectedPaymentOptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => new { x.Id, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Quotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Quotes_PaymentOptions_SelectedPaymentOptionId",
                        column: x => x.SelectedPaymentOptionId,
                        principalTable: "PaymentOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotes_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Quotes_Users_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_OrderId",
                table: "Quotes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_SelectedPaymentOptionId",
                table: "Quotes",
                column: "SelectedPaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_StateId",
                table: "Quotes",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_TransportId",
                table: "Quotes",
                column: "TransportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
