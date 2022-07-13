using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
  public  class ForgetPasswordVM
    {
        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


    }
}
