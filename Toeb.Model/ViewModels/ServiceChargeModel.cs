using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Newtonsoft.Json;

namespace Toeb.Model.ViewModels
{
    class ServiceChargeModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Is it compulsory?")]
        public bool IsCompulsory { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public int TotalAmountPaid { get; set; }

        
        public int EstateId { get; set; }

        [Required]
        public int BuildingId { get; set; } 

        
    }
}
