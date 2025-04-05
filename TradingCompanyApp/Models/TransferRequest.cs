using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingCompanyApp.Models
{
    [Table("TransferRequests")]
    public class TransferRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        [Column("transfer_Request_Date")]
        public DateTime RequestDate { get; set; }
        [Column("transferCompletionDate")]
        public DateTime? CompletionDate { get; set; }
        //public RequestStatus Status { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string SourceWarehouseName { get; set; }
        public virtual Warehouse SourceWarehouse { get; set; }
        public string DestinationWarehouseName { get; set; }
        public virtual Warehouse DestinationWarehouse { get; set; }
        public virtual ICollection<TransferredItem> Items { get; set; } = new List<TransferredItem>();
    }
}
