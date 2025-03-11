using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyApp.Models.Enums;

namespace TradingCompanyApp.Models
{
    internal class Employee : User
    {
        [MaxLength(50)]
        public string FullName { get; set; }
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

    }
}
