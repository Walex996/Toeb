using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Newtonsoft.Json;

namespace Toeb.Model.ViewModels
{
    public class ServiceChargeModel
    {
        [Required]
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
     
    }

    public class ServiceChargeItem : ServiceChargeModel
    {
        public int HouseNumber { get; set; }    
    }

    public class ServiceChargeFilter : ServiceChargeItem
    {

    }
}
