namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Routes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Routes()
        {
            Walks = new HashSet<Walks>();
            RouteStates = new HashSet<RouteStates>();
        }

        [Key]
        public int RouteID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int AlpinistBaseID { get; set; }

        public virtual AlpinistBases AlpinistBases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Walks> Walks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteStates> RouteStates { get; set; }
    }
}
