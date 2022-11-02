using System.Data.Entity;

namespace praktika
{
    public partial class MachineModel : DbContext
    {
        public MachineModel()
            : base("name=MachineModel")
        {
        }


        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Detail_machine> Detail_machine { get; set; }
        public virtual DbSet<Detail_storage> Detail_storage { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<Repairer_machine> Repairer_machine { get; set; }
        public virtual DbSet<Repairers> Repairers { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        //public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
