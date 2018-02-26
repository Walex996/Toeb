using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class EventModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string InviteType { get; set; }

        public int Occurence { get; set; }
    }

    public class EventItem : EventModel
    {
        public IEnumerable<int> InvitedUserIds { get; set; }

        public int InvitedUserCount { get; set; }
    }

    public class EventFilter : EventItem
    {

    }
}
