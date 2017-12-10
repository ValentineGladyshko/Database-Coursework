namespace Coursework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Walk
    {
        [Key]
        public int WalkID { get; set; }

        public int AlpinistID { get; set; }

        public int RouteID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "��������� ����")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ʳ����� ����")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateEnd { get; set; }
    }
}
