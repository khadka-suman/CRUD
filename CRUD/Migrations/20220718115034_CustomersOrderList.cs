using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    public partial class CustomersOrderList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "OrderLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_Customer_Id",
                table: "OrderLists",
                column: "Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLists_Customers_Customer_Id",
                table: "OrderLists",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_Customers_Customer_Id",
                table: "OrderLists");

            migrationBuilder.DropIndex(
                name: "IX_OrderLists_Customer_Id",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "OrderLists");
        }
    }
}
