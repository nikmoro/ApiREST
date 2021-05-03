using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CRUD_API_REST.Models
{
    public partial class ModelDonaciones : DbContext
    {
        public ModelDonaciones()
            : base("name=ModelDonaciones")
        {
        }

        public virtual DbSet<Donacion> Donacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donacion>()
                .Property(e => e.nombre_mpio)
                .IsUnicode(false);

            modelBuilder.Entity<Donacion>()
                .Property(e => e.nombre_arbol)
                .IsUnicode(false);
        }
    }
}
