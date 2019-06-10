using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.ViewModels
{
    public class CreateContactViewModel
    {
        [StringLength(255,ErrorMessage = "First name has to be under 255 characters long")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [StringLength(255,ErrorMessage = "Last name has to be under 255 characters long")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [StringLength(255,ErrorMessage = "Email has to be under 255 characters long")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(13,ErrorMessage ="Mobile has to be under 13 numbers long")]
        [Phone(ErrorMessage = "Please enter a valid mobile number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
    }
}