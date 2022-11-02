namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Repairer_machine
    {
        public int id { get; set; }

        public int Machine_n { get; set; }

        public int repairer_tab_n { get; set; }
    }
}
