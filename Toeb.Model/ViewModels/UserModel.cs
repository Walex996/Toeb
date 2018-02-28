using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class UserItem : UserModel
    {
        public string Name { get; set; }

        public IEnumerable<int> EstateIds { get; set; }

        public int EstateCount { get; set; }
        
        public IEnumerable<int> BuildingIds { get; set; }

        public int BuildingCount { get; set; }

        public IEnumerable<int> ComplaintIds { get; set; }

        public int ComplaintCount { get; set; }

        public IEnumerable<int> EventIds { get; set; }

        public int EventCount { get; set; }

        public IEnumerable<int> ServiceChargeIds { get; set; }

        public int ServiceChargeCount { get; set; }

        public string StateOfOrigin { get; set; }

    }
    public class UserFilter : UserItem
    {
        public DateTime DateCreatedFrom { get; set; }
        public DateTime DateCreatedTo { get; set; }
    }
}
