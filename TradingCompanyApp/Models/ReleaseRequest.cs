using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    internal class ReleaseRequest
    {
        public int ReleaseRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string WarehouseName { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        //public Enums.RequestStatus Status { get; set; }
        public virtual ICollection<ReleaseRequestItem> Items { get; set; } = new HashSet<ReleaseRequestItem>();
    }
}
