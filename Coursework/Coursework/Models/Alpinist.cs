namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alpinist
    {
        public int AlpinistBaseID { get; set; }

        [Required]
        [Display(Name = "І'мя")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
