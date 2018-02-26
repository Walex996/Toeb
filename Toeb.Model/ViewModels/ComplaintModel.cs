using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class ComplaintModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

    }

    public class ComplaintItem : ComplaintModel
    {

    }

    public class ComplaintFilter : ComplaintItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
