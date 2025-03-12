using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingCompanyApp.Migrations
{
    /// <inheritdoc />
    public partial class add_Transfer_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transfer_Request_Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    transferCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SourceWarehouseName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    DestinationWarehouseName = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Warehouses_DestinationWarehouseName",
                        column: x => x.DestinationWarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Warehouses_SourceWarehouseName",
                        column: x => x.SourceWarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transfer_Request_Items",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer_Request_Items", x => new { x.RequestId, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_Transfer_Request_Items_TransferRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TransferRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfer_Request_Items_WarehouseItem_WarehouseId_ItemCode",
                        columns: x => new { x.WarehouseId, x.ItemCode },
                        principalTable: "WarehouseItem",
                        principalColumns: new[] { "WarehouseId", "ItemCode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_Request_Items_WarehouseId_ItemCode",
                table: "Transfer_Request_Items",
                columns: new[] { "WarehouseId", "ItemCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_DestinationWarehouseName",
                table: "TransferRequests",
                column: "DestinationWarehouseName");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_SourceWarehouseName",
                table: "TransferRequests",
                column: "SourceWarehouseName");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_SupplierId",
                table: "TransferRequests",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfer_Request_Items");

            migrationBuilder.DropTable(
                name: "TransferRequests");
        }
    }
}
