using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    internal class Customer : User
    {
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        [StringLength(13)]
        public string MobileNumber { get; set; }
        [StringLength(50)]
        public string FaxNumber { get; set; }
        [StringLength(75)]
        public string Website { get; set; }
        //public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
