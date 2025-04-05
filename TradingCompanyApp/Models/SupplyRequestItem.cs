using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    public class SupplyRequestItem
    {
        [ForeignKey("SupplyRequest")]
        public int RequestId { get; set; }
        public virtual SupplyRequest SupplyRequest { get; set; }
        public int WarehouseId { get; set; }
        public string ItemCode { get; set; }
        public virtual WarehouseItem Item { get; set; }
        public double Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
