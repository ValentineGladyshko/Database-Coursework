namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Houses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Houses()
        {
            HouseOrders = new HashSet<HouseOrders>();
        }

        [Key]
        public int HouseID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int HouseTypeID { get; set; }

        public int AlpinistBaseID { get; set; }

        public virtual AlpinistBases AlpinistBases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseOrders> HouseOrders { get; set; }

        public virtual HouseTypes HouseTypes { get; set; }
    }
}
