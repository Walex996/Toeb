namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complaint")]
    public partial class Complaint
    {
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int BuildingId { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

        public virtual Building Building { get; set; }

        public virtual User User { get; set; }
    }
}
