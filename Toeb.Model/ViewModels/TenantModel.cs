using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class TenantModel:UserModel
    {
        public int UserId { get; set; }

        public int BuildingId { get; set; }

        public int EstateId { get; set; }
    }

    public class TenantItem:TenantModel
    {
        public string EstateName { get; set; }
        public string Sex { get; set; }
        public string StateOfOrigin { get; set; }
        public string HouseNumber { get; set; }
    }
    public class TenantFilter : TenantItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
