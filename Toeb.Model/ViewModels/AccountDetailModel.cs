using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class AccountDetailModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }
    }

    public class AccountDetailItem : AccountDetailModel
    {

    }

    public class AccountDetailFilter : AccountDetailItem
    {

    }
}
