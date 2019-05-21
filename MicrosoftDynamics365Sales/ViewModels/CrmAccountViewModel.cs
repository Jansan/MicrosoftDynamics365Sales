using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.ViewModels
{
    public class CrmAccountViewModel
    {
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "UserId email is required")]
        public string UserIdEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "CRM Web service")]
        [DataType(DataType.Url)]
        [Required(ErrorMessage = "CRM Web service URL is required")]
        public string CrmWebServiceUrl { get; set; }
    }
}