namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Repairers
    {
        public int id { get; set; }

        public int tab_n { get; set; }

        [Required]
        [StringLength(1000)]
        public string FIO { get; set; }

        public int experience { get; set; }

        public int Phone_number { get; set; }
    }
}
