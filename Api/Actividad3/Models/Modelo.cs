namespace Actividad3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<medicamento> medicamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<medicamento>()
                .Property(e => e.medicamento1)
                .IsUnicode(false);

            modelBuilder.Entity<medicamento>()
                .Property(e => e.marca)
                .IsUnicode(false);
        }
    }
}
