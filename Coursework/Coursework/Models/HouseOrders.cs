namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HouseOrders
    {
        [Key]
        public int HouseOrderID { get; set; }

        public int AlpinistID { get; set; }

        public int HouseID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        public virtual Alpinists Alpinists { get; set; }

        public virtual Houses Houses { get; set; }
    }
}
