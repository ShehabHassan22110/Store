using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entity
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Phone { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
    }
}
