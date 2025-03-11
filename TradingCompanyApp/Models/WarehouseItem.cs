using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    internal class WarehouseItem
    {
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        [ForeignKey("Item")]
        public string ItemCode { get; set; }
        public virtual Item Item { get; set; }
        public double Quantity { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
