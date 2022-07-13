using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
  public  class RegistrationVM    
    {
        [Required(ErrorMessage = "This Field is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]

        public string Password { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 & Capital Charachters ")]
        [Compare("Password",ErrorMessage ="Password not match ")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
