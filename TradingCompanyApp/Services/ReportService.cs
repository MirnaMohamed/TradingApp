using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyApp.Models.Reports;

namespace TradingCompanyApp.Services
{
    public static class ReportService
    {
        private static readonly ApplicationDbContext context = new ApplicationDbContext();
        internal static WarehouseReport GetWarehouseReport(int warehouseId, DateTime? startDate, DateTime? endDate)
        {
            var warehouse = context.Warehouses
                .FirstOrDefault(w => w.WarehouseId == warehouseId);

            if (warehouse == null)
                throw new Exception($"Warehouse with ID {warehouseId} not found.");

            var initialStock = warehouse.Items
                .Select(item => new WarehouseReportItem
                {
                    ItemCode = item.ItemCode,
                    Quantity = item.Quantity
                }).ToList();

            var supplyTransactions = context.SupplyRequests
                .Where(r => r.WarehouseName == warehouse.Name && r.RequestDate >= startDate && r.RequestDate <= endDate)
                .ToList();

            var releaseTransactions = context.ReleaseRequests
                .Where(r => r.WarehouseName == warehouse.Name && r.RequestDate >= startDate && r.RequestDate <= endDate)
                .ToList();

            var transferTransactions = context.TransferRequests
                .Where(r => r.SourceWarehouseName == warehouse.Name || r.DestinationWarehouseName == warehouse.Name)
                .Where(r => r.RequestDate >= startDate && r.RequestDate <= endDate)
                .ToList();

            var finalStock = warehouse.Items
                .Select(item => new WarehouseReportItem
                {
                    ItemCode = item.ItemCode,
                    Quantity = item.Quantity
                }).ToList();

            return new WarehouseReport
            {
                WarehouseId = warehouseId,
                WarehouseName = warehouse.Name,
                StartDate = startDate,
                EndDate = endDate,
                InitialStock = initialStock,
                SupplyRequests = supplyTransactions,
                ReleaseRequests = releaseTransactions,
                TransferRequests = transferTransactions,
                CurrentStock = finalStock
            };
        }

    }
}
