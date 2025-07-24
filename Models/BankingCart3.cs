using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Target1.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Target1.Models
{
    public class BankingCart3
    {
        public int Id { get; set; }
     
        public int BanksId { get; set; }
        [ForeignKey(nameof(BanksId))]
        [ValidateNever]
        public Banks? Banks { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId ")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 600")]
        public int Month { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Loan { get; set; }
        [NotMapped]
        public double Monthy { get; set; }
        [NotMapped]
        public double Biweekly { get; set; }
        [NotMapped]
        public double Bestrate { get; set; }
        [NotMapped]
        public double Credit { get; set; }







    }
}

