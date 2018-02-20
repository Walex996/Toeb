namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountDetail")]
    public partial class AccountDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountDetail()
        {
            ServiceCharges = new HashSet<ServiceCharge>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        public int AccountType { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }

        public int EstateOwnerId { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCharge> ServiceCharges { get; set; }
    }
}
