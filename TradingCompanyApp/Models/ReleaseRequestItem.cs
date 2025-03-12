using System.ComponentModel.DataAnnotations.Schema;

namespace TradingCompanyApp.Models
{
    [Table("Release_Request_Items")]
    internal class ReleaseRequestItem
    {
        [ForeignKey("ReleaseRequest")]
        public int RequestId { get; set; }
        public virtual ReleaseRequest ReleaseRequest { get; set; }
        public string ItemCode { get; set; }
        public int WarehouseId { get; set; }
        public virtual WarehouseItem Item { get; set; }
        public double Quantity { get; set; }

    }
}
