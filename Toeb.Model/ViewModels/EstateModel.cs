using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class EstateModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public int StateId { get; set; }

        public int SubscriptionId { get; set; }

        public int? LgaId { get; set; }
    }

    public class EstateItem : EstateModel
    {
        public int EventCount { get; set; }
        public int SubscriptionCount { get; set; }
    }

    public class EstateFilter : EstateItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
