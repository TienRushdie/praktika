namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Storage")]
    public partial class Storage
    {
        public int Id { get; set; }

        public int Storage_n { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        public int Square { get; set; }
    }
}
