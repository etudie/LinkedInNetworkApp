namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("connectionstrackerapp.records")]
    public partial class record
    {
        public int id { get; set; }

        [StringLength(60)]
        public string name { get; set; }

        [StringLength(45)]
        public string company { get; set; }

        [StringLength(45)]
        public string stage { get; set; }

        [StringLength(45)]
        public string platform { get; set; }

        [StringLength(45)]
        public string platformURL { get; set; }

        [StringLength(45)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? lastContacted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? firstContacted { get; set; }

        public int? priority { get; set; }

        public int iduser { get; set; }
    }
}
