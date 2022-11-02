namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_machine
    {
        public int Id { get; set; }

        public int Machine_n { get; set; }

        public int Detail_n { get; set; }
    }
}
