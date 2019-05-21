using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Account Name is required")]
        public string AccountName { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "VatNumber")]
        [Required(ErrorMessage = "VatNumber is required")]
        public string VatNumber { get; set; }


    }
}