namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RouteStates
    {
        [Key]
        public int RouteStateID { get; set; }

        [Required]
        [StringLength(255)]
        public string State { get; set; }

        public int RouteID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        public virtual Routes Routes { get; set; }
    }
}
