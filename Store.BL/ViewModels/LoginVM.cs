using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
   public class LoginVM
    {
        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
