using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Target1.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId ")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? CodePostal { get; set; }
    }
}


