namespace CRUD_API_REST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donacion")]
    public partial class Donacion
    {
        public int id { get; set; }

        [StringLength(250)]
        public string nombre_mpio { get; set; }

        [StringLength(50)]
        public string nombre_arbol { get; set; }

        public int? cantidad { get; set; }
    }
}
