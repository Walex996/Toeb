using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.Model.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int Role { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int StateOfOriginId { get; set; }

        public int NextOfKinId { get; set; }

        public int Gender { get; set; }
    }

    public class UserItem : UserModel
    {
        public string Name { get; set; }

        public IEnumerable<int> EstateIds { get; set; }
        public int EstateCount { get; set; }
        public IEnumerable<int> BuildingIds { get; set; }
    }
    public class UserFilter : UserItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
