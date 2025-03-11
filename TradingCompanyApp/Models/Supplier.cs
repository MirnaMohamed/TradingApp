using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingCompanyApp.Models
{
    internal class Supplier : User
    {
        [Required, StringLength(50)]
        public string SupplierName { get; set; }
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        [StringLength(13)]
        public string MobileNumber { get; set; }
        [StringLength(50)]
        public string FaxNumber { get; set; }
        [StringLength(75)]
        public string Website { get; set; }
    }
}
