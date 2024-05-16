using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Orderings_OrderingId",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_OrderingId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orderings_OrderingId",
                table: "OrderDetails",
                column: "OrderingId",
                principalTable: "Orderings",
                principalColumn: "OrderingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orderings_OrderingId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderingId",
                table: "MyProperty",
                newName: "IX_MyProperty_OrderingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Orderings_OrderingId",
                table: "MyProperty",
                column: "OrderingId",
                principalTable: "Orderings",
                principalColumn: "OrderingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
