using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class StateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the state name")]
        [RegularExpression("[A-Za-z]",ErrorMessage ="Numbers not allowed"), ]
        [StringLength(50)]
        public string Name { get; set; } 
    }
    public class StateItem:StateModel
    {
        public int EstateCount { get; set; }
    }
    public class StateFilter:StateItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
