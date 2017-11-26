namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodOrders
    {
        [Key]
        public int FoodOrderID { get; set; }

        public int AlpinistID { get; set; }

        public int FoodTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Alpinists Alpinists { get; set; }

        public virtual FoodTypes FoodTypes { get; set; }
    }
}
