namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCharge")]
    public partial class ServiceCharge
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public bool IsCompulsory { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal? TotalAmountPaid { get; set; }

        public int EstateOwnerId { get; set; }

        public int BuildingId { get; set; }

        public int AccountId { get; set; }

        public int DueDay { get; set; }

        public int DueMonth { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }

        public virtual Building Building { get; set; }

        public virtual User User { get; set; }
        public string BuildingIds { get; set; }
    }
}
