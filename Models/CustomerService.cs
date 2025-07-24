
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target1.Models
{
    public class CustomerService
    {
        public IEnumerable<BankingCart3> LstCart { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Customer))]
        [ValidateNever]
        public Customer? Customer { get; set; }
        public int Monthes { get; set; }
        public string BankName { get; set; }
        public double LoanTotal { get; set; }
        public double Rate { get; set; }
        public double MonthlyPay { get; set; }
        public double Monthly { get; set; }
        public double Credit { get; set; }
        public int BankId { get; set; }
        [ForeignKey(nameof(Banks))]
        [ValidateNever]
        public Banks? Banks { get; set; }


    }

}




