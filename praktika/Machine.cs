namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Machine")]
    public partial class Machine
    {
        public int ID { get; set; }

        public int Machinenumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string Model { get; set; }

        [Required]
        [StringLength(1000)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_start { get; set; }

        public int Work_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_end { get; set; }
    }
}
