using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Target1.Models
{
    public class Banks
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "BankId")]
        public int? BankId { get; set; }
        [Display(Name = "BankName")]
        public string BankName { get; set; }
        [Display(Name = "Rates")]
        public double Rates { get; set; }
        [Display(Name = "LimitLine")]
        public int LimitLine { get; set; }
        [ValidateNever]
        public string? Imagurl { get; set; }



    }
}
