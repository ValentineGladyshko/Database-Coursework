namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlpinistsList")]
    public partial class AlpinistsList
    {
        public int AlpinistsListID { get; set; }

        public int AlpinistID { get; set; }

        public int AlpinistBaseID { get; set; }

        public virtual AlpinistBases AlpinistBases { get; set; }

        public virtual Alpinists Alpinists { get; set; }
    }
}
