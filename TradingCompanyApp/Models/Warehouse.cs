using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    public class Warehouse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Address { get; set; }

        public int ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        public virtual ICollection<SupplyRequest> SupplyRequests { get; set; } = new HashSet<SupplyRequest>();
        public virtual ICollection<ReleaseRequest> ReleaseRequests { get; set; } = new HashSet<ReleaseRequest>();
        public virtual ICollection<TransferRequest> IncomingTransferRequests { get; set; } = new HashSet<TransferRequest>();
        public virtual ICollection<TransferRequest> OutgoingTransferRequests { get; set; } = new HashSet<TransferRequest>();

        //public virtual ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
        public virtual ICollection<WarehouseItem> Items { get; set; } = new HashSet<WarehouseItem>();
        public virtual ICollection<User> AuthorizedUsers { get; set; } = new HashSet<User>();

        public override string ToString()
        {
            string output = $"ID: {WarehouseId} - Name: {Name} - Address: {Address} ";
            for(int i = 0; i< Items.Count; i++)
            {
                WarehouseItem item = Items.ElementAt(i) ;
                output += $"Item Code: {item.ItemCode} - Quantity: {item.Quantity}";
            }

            return output;
        }
    }
}
