using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
   public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public String Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Brand Is Required")]
        public String Brand { get; set; }
        [Required(ErrorMessage = "Model Is Required")]
        public int ModelYear { get; set; }
        public int Salary { get; set; }
        public String Offer { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Vat { get; set; }
        public double Total { get; set; }
    }
}
