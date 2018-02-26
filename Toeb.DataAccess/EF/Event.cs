namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string InviteType { get; set; }

        public int Occurence { get; set; }

        public int EstateId { get; set; }

        public IEnumerable<int> InvitedUserIds { get; set; }

        public virtual Estate Estate { get; set; }

        public virtual User User { get; set; }
    }
}
