using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    internal class ItemRequest
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string WarehouseName { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
