namespace Actividad3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicamento")]
    public partial class medicamento
    {
        public int id { get; set; }

        [Column("medicamento")]
        [StringLength(50)]
        public string medicamento1 { get; set; }

        [StringLength(50)]
        public string marca { get; set; }
    }
}
