using TradingCompanyApp.Models.Reports;

namespace TradingCompanyApp.Services
{
    internal static class WarehouseService
    {
        static ApplicationDbContext context = ApplicationDbContext.context;
        internal static void UpdateWarehouseById(int id, Dictionary<string, object> options)
        {
            var warehouse = context.Warehouses.Find(id);
            if (warehouse == null)
                MessageBox.Show($"Warehouse with ID {id} is not found");
            else
            {
                for (int i = 0; i < options.Count; i++)
                {
                    switch (options.ElementAt(i).Key)
                    {
                        case "Name":
                            warehouse.Name = options.ElementAt(i).Value.ToString();
                            break;
                        case "Address":
                            warehouse.Address = options.ElementAt(i).Value.ToString();
                            break;
                        case "Manager ID":
                            warehouse.ManagerId = (int) options.ElementAt(i).Value;
                            break;
                    }
                }
                context.Warehouses.Update(warehouse);
                context.SaveChanges();
            }
        }
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
