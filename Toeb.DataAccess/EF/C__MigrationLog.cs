namespace Toeb.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("__MigrationLog")]
    public partial class C__MigrationLog
    {
        [Key]
        [Column(Order = 0)]
        public Guid migration_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string script_checksum { get; set; }

        [Required]
        [StringLength(255)]
        public string script_filename { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime complete_dt { get; set; }

        [Required]
        [StringLength(100)]
        public string applied_by { get; set; }

        public byte deployed { get; set; }

        [StringLength(255)]
        public string version { get; set; }

        [StringLength(255)]
        public string package_version { get; set; }

        [StringLength(255)]
        public string release_version { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sequence_no { get; set; }
    }
}
