using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class ServiceChargeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public bool IsCompulsory { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal? TotalAmountPaid { get; set; }

        public int DueDay { get; set; }

        public int DueMonth { get; set; }

        public string BuildingIds { get; set; }
        public List<int> BuildingModelIds { get; set; }
    }


    public class ServiceChargeItem : ServiceChargeModel
    {
        public int BuildingCount { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int AccountType { get; set; }
        public string BankName { get; set; }

    }

    public class ServiceChargeFilter : ServiceChargeItem
    {

    }
}
