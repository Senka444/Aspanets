namespace Aspanets.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Application = new HashSet<Application>();
        }

        public int Id { get; set; }

        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? IsDepartment { get; set; }

        public int? IsSubdivision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Application { get; set; }

        public virtual Department Department { get; set; }

        public virtual Subdivision Subdivision { get; set; }
    }
}
