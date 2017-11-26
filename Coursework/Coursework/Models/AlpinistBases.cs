namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlpinistBases
    {
        public AlpinistBases()
        {
            Houses = new HashSet<Houses>();
            AlpinistsList = new HashSet<AlpinistsList>();
            Routes = new HashSet<Routes>();
        }

        [Key]
        public int AlpinistBaseID { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public virtual ICollection<Houses> Houses { get; set; }

        public virtual ICollection<AlpinistsList> AlpinistsList { get; set; }

        public virtual ICollection<Routes> Routes { get; set; }
    }
}
