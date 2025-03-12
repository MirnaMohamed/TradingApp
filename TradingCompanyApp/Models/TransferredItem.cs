using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    [Table("Transfer_Request_Items")]
    internal class TransferredItem
    {
        [ForeignKey("TransferRequest")]
        public int RequestId { get; set; }
        public string ItemCode { get; set; }
        public int WarehouseId { get; set; }
        public double Quantity { get; set; }
        public virtual TransferRequest TransferRequest { get; set; }
        public virtual WarehouseItem Item { get; set; }
    }
}
