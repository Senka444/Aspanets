namespace Aspanets.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        public int Id { get; set; }

        public int Whom { get; set; }

        public int IdVisitor { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int? Aim { get; set; }

        public int? IdStatus { get; set; }

        [StringLength(10)]
        public string Desctiption { get; set; }

        public virtual Aims Aims { get; set; }

        public virtual Status Status { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
