using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradingCompanyApp.Models.Enums;

namespace TradingCompanyApp.Models
{
    [Table("Items")]
    internal class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), MaxLength(25)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        //public string Description { get; set; }
        //public double Price { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        [EnumDataType(typeof(MeasurementUnit))]
        public MeasurementUnit Unit { get; set; }
    }
}
