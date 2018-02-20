namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tenant")]
    public partial class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public int BuildingId { get; set; }

        public int EstateId { get; set; }

        public virtual Building Building { get; set; }

        public virtual Estate Estate { get; set; }

        public virtual User User { get; set; }
    }
}
