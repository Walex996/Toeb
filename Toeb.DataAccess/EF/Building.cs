namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Building")]
    public partial class Building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
            Complaints = new HashSet<Complaint>();
            ServiceCharges = new HashSet<ServiceCharge>();
            Tenants = new HashSet<Tenant>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int EstateId { get; set; }

        public int HouseNumber { get; set; }

        public int NumberOfFlat { get; set; }

        public int StructureId { get; set; }

        public int NumberOfTenant { get; set; }

        public virtual Estate Estate { get; set; }

        public virtual Structure Structure { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCharge> ServiceCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
