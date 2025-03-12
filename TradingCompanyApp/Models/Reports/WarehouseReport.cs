using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models.Reports
{
    internal class WarehouseReport
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.MinValue;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public List<WarehouseReportItem> InitialStock { get; set; }
        public List<SupplyRequest> SupplyRequests { get; set; }
        public List<ReleaseRequest> ReleaseRequests { get; set; }
        public List<TransferRequest> TransferRequests { get; set; }
        public List<WarehouseReportItem> CurrentStock { get; set; }
    }

    public class WarehouseReportItem
    {
        public string ItemCode { get; set; }
        public double Quantity { get; set; }
    }
}
