using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandesBank.Models
{
    public class WithdrawalModel
    {
        [DataType(DataType.Currency)]
        [Display(Name = "Cash To Withdrawal")]
        [Range(1000, 50000)]
        public double AmountToWithdrawal { get; set; }
    }
}