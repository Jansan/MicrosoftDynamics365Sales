using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.ViewModels
{
    public class CreateContactViewModel
    {
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(255)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
    }
}