namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Walks
    {
        [Key]
        public int WalkID { get; set; }

        public int AlpinistID { get; set; }

        public int RouteID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        public virtual Alpinists Alpinists { get; set; }

        public virtual Routes Routes { get; set; }
    }
}
