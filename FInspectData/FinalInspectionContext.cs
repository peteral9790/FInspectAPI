namespace FInspectData
{
    using FInspectData.Models;
    using System.Data.Entity;

    public class FinalInspectionContext : DbContext
    {
        public FinalInspectionContext()
            : base("name=FinalInspectionContext")
        {
        }

        public virtual DbSet<FinalInspection> FinalInspections { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Nonconformance> Nonconformances { get; set; }
        public virtual DbSet<Assembly> Assemblies { get; set; }
        public virtual DbSet<MiStatusTransaction> MiStatusTransactions { get; set; }
        public virtual DbSet<FinalInspectionUpload> FinalInspectionUploads { get; set; }
    }
}