namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detail")]
    public partial class Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Detail_number { get; set; }

        [Required]
        [StringLength(1000)]
        public string Detail_name { get; set; }

        public int Detail_Cost { get; set; }
    }
}
