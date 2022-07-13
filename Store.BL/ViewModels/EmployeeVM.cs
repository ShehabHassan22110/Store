using Store.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
   public class EmployeeVM
    {
        //public int Id { get; set; }
        //[Required(ErrorMessage ="Name Required")]
        //[MinLength(3,ErrorMessage ="Min Len 3")]
        //public string Name { get; set; }
        //[Required(ErrorMessage = "Code Required")]
        //public string Code { get; set; }
        //[Required(ErrorMessage = "Phone Required")]
        //public string Phone { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Phone { get; set; }
        public string PhotoName { get; set; } 
        public string CvName { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }



    }
}
