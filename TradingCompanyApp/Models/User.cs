using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Models
{
    [Table("Users")]
    internal class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [MaxLength(29), RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{7,29}$")]
        public string? Username { get; set; }
        [Required, MaxLength(50), RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Invalid Email address.")]
        public required string Email { get; set; }
        [MaxLength(25), RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public required string Password { get; set; }
        public virtual ICollection<Warehouse> AccessibleWarehouses { get; set; } = new HashSet<Warehouse>();
    }
}
