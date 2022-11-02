namespace praktika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_storage
    {
        public int Id { get; set; }

        public int storage_n { get; set; }

        public int detail_n { get; set; }
    }
}
